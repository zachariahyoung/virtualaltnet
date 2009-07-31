using NUnit.Framework;
using Rhino.Mocks;
using van.Web.Controllers.Infrastructure;

namespace Tests.van.Web.Controllers {
    [TestFixture]
    public class RequiresAuthenticationAttributeTests {
        [Test]
        public void CanRedirectToLoginWhenNotAuthenticated()
        {

            //arrange
            var mockedProvider = MockRepository.GenerateMock<IAuthenticationProvider>();
            mockedProvider.Expect(x => x.IsAuthenticated(null)).IgnoreArguments().Return(false);
            mockedProvider.Expect(x => x.RedirectToLogin(null)).IgnoreArguments();
            //act 
            var attribute = new RequiresAuthenticationAttribute(mockedProvider);
            attribute.OnActionExecuting(null);
            //assert
            mockedProvider.VerifyAllExpectations();
        }

        [Test]
        public void CanPassThroughWhenAuthenticated()
        {
            //arrange
            var mockedProvider = MockRepository.GenerateMock<IAuthenticationProvider>();
            mockedProvider.Expect(x => x.IsAuthenticated(null)).IgnoreArguments().Return(true);
            //act 
            var attribute = new RequiresAuthenticationAttribute(mockedProvider);
            attribute.OnActionExecuting(null);
            //assert
            mockedProvider.AssertWasNotCalled(x => x.RedirectToLogin(null));
            mockedProvider.VerifyAllExpectations();
        }

    }
}