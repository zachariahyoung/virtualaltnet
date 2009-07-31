using System.Web.Mvc;
using Microsoft.Practices.ServiceLocation;
using van.Core.DataInterfaces;

namespace van.Web.Controllers.Infrastructure
{
    public class RequiresAuthorizationAttribute : ActionFilterAttribute {
        private readonly IAuthorizationProvider authorizationProvider;
        private readonly IAccountRepository accountRepository;
        private readonly IUserRepository userRepository;

        public string RoleToCheckFor { get; set; }

        public RequiresAuthorizationAttribute(IAuthorizationProvider provider, IAccountRepository accountRepository, IUserRepository userRepository )
        {
            authorizationProvider = provider;
            this.accountRepository = accountRepository;
            this.userRepository = userRepository;
        }
        public RequiresAuthorizationAttribute() : this(ServiceLocator.Current.GetInstance<IAuthorizationProvider>(), 
            ServiceLocator.Current.GetInstance<IAccountRepository>(),ServiceLocator.Current.GetInstance<IUserRepository>()) { }
 
 
 
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!authorizationProvider.IsAuthorized(filterContext, RoleToCheckFor,userRepository, accountRepository)) {
                authorizationProvider.RedirectToDenied(filterContext);
            }
        }
      
    }
}