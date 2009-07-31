using System.Web.Mvc;
using van.Core.DataInterfaces;

namespace van.Web.Controllers.Infrastructure
{
    public interface IAuthorizationProvider {
        bool IsAuthorized(ControllerContext context, string roleToCheck, IUserRepository userRepository, IAccountRepository accountRepository);
        void RedirectToDenied(ControllerContext context);
    }
}