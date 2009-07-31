using System.Web.Mvc;
using Microsoft.Practices.ServiceLocation;

namespace van.Web.Controllers.Infrastructure
{
     public class RequiresAuthenticationAttribute : ActionFilterAttribute
    {
        public RequiresAuthenticationAttribute(IAuthenticationProvider provider) {
            authenticationProvider = provider;    
        }
 
        public RequiresAuthenticationAttribute() : this(ServiceLocator.Current.GetInstance<IAuthenticationProvider>()) {}
 
 
 
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!authenticationProvider.IsAuthenticated(filterContext)) {
                authenticationProvider.RedirectToLogin(filterContext);
            }
        }
        private readonly IAuthenticationProvider authenticationProvider;
    }
}