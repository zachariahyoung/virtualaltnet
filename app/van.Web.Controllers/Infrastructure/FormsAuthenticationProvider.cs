using System.Web.Mvc;
using System.Web.Security;
using van.Core;
using van.Core.DataInterfaces;

namespace van.Web.Controllers.Infrastructure {
    public class FormsAuthenticationProvider : IAuthenticationProvider, IAuthorizationProvider{
       
        #region Implementation of IAuthenticationProvider
       
        public bool IsAuthenticated(ControllerContext context)
        {
            return context.HttpContext.User.Identity.IsAuthenticated;

        }

        public void RedirectToLogin(ControllerContext context)
        {
            context.HttpContext.Response.Redirect(FormsAuthentication.LoginUrl + string.Format("?ReturnUrl={0}", context.HttpContext.Request.Url.AbsolutePath), true);

        }

        public virtual void SetAuthCookie(string userName, bool createPersistentCookie)
        {
            FormsAuthentication.SetAuthCookie(userName, createPersistentCookie);
        }

        #endregion

        #region Implementation of IAuthorizationProvider

        public bool IsAuthorized(ControllerContext context, string roleToCheck, IUserRepository userRepository, IAccountRepository accountRepository)
        {
            if (IsAuthenticated(context))
            {
                var user = userRepository.GetByUserName(context.HttpContext.User.Identity.Name);
                Account account = accountRepository.GetRoleForUser(user.Id);
                return account.Name.ToLower() == roleToCheck.ToLower();
            }
            return false;

            //return context.HttpContext.User.IsInRole(roleToCheck);
        }

        public void RedirectToDenied(ControllerContext context)
        {
            context.HttpContext.Response.Redirect("~/Membership/Denied",false);
        }

        #endregion

      
    }
}
