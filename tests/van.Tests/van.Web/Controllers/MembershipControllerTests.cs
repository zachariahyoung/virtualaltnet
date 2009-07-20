using System.Web.Mvc;
using MvcContrib.TestHelper;
using NUnit.Framework;
using Rhino.Mocks;
using van.Web.Controllers;
using van.Web.Controllers.Infrastructure;

namespace Tests.van.Web.Controllers {
    [TestFixture]
    public class MembershipControllerTests {
        private MembershipController controller;
        private IMembershipProvider mockedMembershipProvider;
        private IAuthenticationProvider mockedAuthenticationProvider;
        private IAuthorizationProvider mockedAuthorizationProvider;

        [SetUp]
        public void SetUp()
        {
            ServiceLocatorInitializer.Init();
            controller = new MembershipController();

            mockedMembershipProvider = MockRepository.GenerateMock<IMembershipProvider>();
            mockedAuthenticationProvider = MockRepository.GenerateMock<IAuthenticationProvider>();
            mockedAuthorizationProvider = MockRepository.GenerateMock<IAuthorizationProvider>();

        }

        [Test]
        public void CanInitUserLogin()
        {
            ViewResult result = controller.Login().AssertViewRendered();
        }

        [Test]
        public void CanAuthenticate()
        {
            //arrange
            var membershipController = new MembershipController(mockedAuthenticationProvider, mockedAuthorizationProvider,mockedMembershipProvider);
            string validationMessage = "User is authenticated";

            mockedMembershipProvider.Expect(x => x.ValidateUser(null, null, out validationMessage)).IgnoreArguments().Return(true);
            mockedMembershipProvider.Expect(x => x.AuthorizeUser(null, out validationMessage)).IgnoreArguments().Return(true);
            mockedAuthenticationProvider.Expect(x => x.SetAuthCookie(null,true)).IgnoreArguments();
            
            //act, assert
            RedirectResult  redirectResult = membershipController.Authenticate(null, null, "rememberme", "/").AssertHttpRedirect();
            mockedMembershipProvider.VerifyAllExpectations();
            mockedAuthenticationProvider.VerifyAllExpectations();
        }

        [Test]
        public void CanRedirectToLoginWhenNotAuthenticated()
        {
            //arrange
            var membershipController = new MembershipController(mockedAuthenticationProvider, mockedAuthorizationProvider,mockedMembershipProvider);
            string validationMessage = "Not Authenticated";

            //when validate user returns false
            mockedMembershipProvider.Expect(x => x.ValidateUser("", "", out validationMessage)).IgnoreArguments().Return(false);

            //act, assert
            ViewResult viewResult = membershipController.Authenticate("username", "password", "rememberme", "/").AssertViewRendered();
            Assert.IsNotNull(membershipController.ViewData["ErrorMessage"]);

            mockedAuthenticationProvider.AssertWasNotCalled(x => x.SetAuthCookie("username", true));
            mockedMembershipProvider.VerifyAllExpectations();
        }

    }
}
