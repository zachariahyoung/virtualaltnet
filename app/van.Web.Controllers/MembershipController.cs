using System.Web.Mvc;
using Microsoft.Practices.ServiceLocation;
using SharpArch.Web.NHibernate;
using van.Core;
using van.Web.Controllers.Infrastructure;
using van.Web.Core;

namespace van.Web.Controllers {
    
    [HandleErrorAttribute]
    public class MembershipController : Controller {

        private readonly IAuthenticationProvider authenticationProvider;
        private readonly IAuthorizationProvider authorizationProvider;
        private readonly IMembershipProvider membershipProvider;

        public MembershipController(IAuthenticationProvider authenticationProvider, IAuthorizationProvider authorizationProvider, IMembershipProvider membershipProvider)
        {
            this.authenticationProvider = authenticationProvider;
            this.authorizationProvider = authorizationProvider;
            this.membershipProvider = membershipProvider;
        }

        public MembershipController()
            : this(ServiceLocator.Current.GetInstance<IAuthenticationProvider>(),ServiceLocator.Current.GetInstance<IAuthorizationProvider>(),
                   ServiceLocator.Current.GetInstance<IMembershipProvider>()) { }

        [Transaction]
		  [ResourceFilter(1)] 
        public ActionResult Login()
        {
            return View("Login");
        }

		  [ResourceFilter(1)] 
        public ActionResult Denied()
        {
			  return View("Denied");
        }
        [Transaction]
        public ActionResult Authenticate(string userName, string password, string rememberMe, string returnUrl)
        {

            string validationMessage;
            if (membershipProvider.ValidateUser(userName, password, out validationMessage)
                && membershipProvider.AuthorizeUser(userName, out validationMessage)) {
                authenticationProvider.SetAuthCookie(userName, (rememberMe != null));
                return new RedirectResult(returnUrl);
            }
            validationMessage = "Please Login";
            ViewData["ErrorMessage"] = validationMessage;
            return View("Login");
        }
    }

}
