using System.Web.Mvc;

namespace van.Web.Controllers.Infrastructure
{
    public interface IAuthenticationProvider {
        bool IsAuthenticated(ControllerContext context);
        void RedirectToLogin(ControllerContext context);
        void SetAuthCookie(string userName, bool createPersistentCookie);

    }
}