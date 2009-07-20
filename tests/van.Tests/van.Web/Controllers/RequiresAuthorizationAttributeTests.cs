using NUnit.Framework;
using Rhino.Mocks;
using van.Core.DataInterfaces;
using van.Web.Controllers.Infrastructure;

namespace Tests.van.Web.Controllers {
    [TestFixture]
    public class RequiresAuthorizationAttributeTests {
        [Test]
        public void CanRedirectToDeniedWhenNotAuthorized()
        {
            //arrange
            var mockedProvider = MockRepository.GenerateMock<IAuthorizationProvider>();
            var mockedAccountRepository = MockRepository.GenerateMock<IAccountRepository>();
            var mockedUserRepository = MockRepository.GenerateMock<IUserRepository>();

            mockedUserRepository.Expect(x => x.GetByUserName("")).IgnoreArguments().Return(null);
            mockedAccountRepository.Expect(x => x.GetRoleForUser("")).IgnoreArguments().Return(null);
            mockedProvider.Expect(x => x.IsAuthorized(null, null, null,null)).IgnoreArguments().Return(false);
            mockedProvider.Expect(x => x.RedirectToDenied(null)).IgnoreArguments();
            //act 
            var attribute = new RequiresAuthorizationAttribute(mockedProvider,mockedAccountRepository,mockedUserRepository);
            attribute.OnActionExecuting(null);
            //assert
            mockedProvider.VerifyAllExpectations();
        }
        [Test]
        public void CanPassThroughWhenAuthorized()
        {
            //arrange
            var mockedProvider = MockRepository.GenerateMock<IAuthorizationProvider>();
            var mockedAccountRepository = MockRepository.GenerateMock<IAccountRepository>();
            var mockedUserRepository = MockRepository.GenerateMock<IUserRepository>();
            

            mockedUserRepository.Expect(x => x.GetByUserName("Digby")).IgnoreArguments().Return(null);
            mockedAccountRepository.Expect(x => x.GetRoleForUser("Digby")).IgnoreArguments().Return(null);
            mockedProvider.Expect(x => x.IsAuthorized(null, null, null, null)).IgnoreArguments().Return(true);
            
            
            //act 
            var attribute = new RequiresAuthorizationAttribute(mockedProvider,mockedAccountRepository,mockedUserRepository);
            attribute.OnActionExecuting(null);
            //assert
            mockedProvider.AssertWasNotCalled(x => x.RedirectToDenied(null));
            mockedProvider.VerifyAllExpectations();
        }
    }
}
