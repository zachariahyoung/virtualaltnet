using System;
using System.Web;
using System.Web.Mvc;
using DotNetOpenAuth.OpenId.RelyingParty;

namespace van.Web.Controllers.Infrastructure {
    public class OpenIdAuthenticationProvider : IAuthenticationProvider {
        public void IsValidLogin(Uri serviceUri)
        {
            var result = false;

            var openid = new OpenIdRelyingParty();
            if (openid.GetResponse() == null) {
                // Stage 2: user submitting Identifier
                openid.CreateRequest(HttpRequest.Request.Form["openid_identifier"]).RedirectToProvider();
            }
            else {
                // Stage 3: OpenID Provider sending assertion response
                switch (openid.Response.Status) {
                    case AuthenticationStatus.Authenticated:
                        FormsAuthenticationProvider.RedirectFromLoginPage(openid.Response.ClaimedIdentifier, false);
                        break;
                    case AuthenticationStatus.Canceled:
                        ViewData["Message"] = "Canceled at provider";
                        RenderView("Login");
                        break;
                    case AuthenticationStatus.Failed:
                        ViewData["Message"] = openid.Response.Exception.Message;
                        RenderView("Login");
                        break;
                }
            }
        }

        #region Implementation of IAuthenticationProvider

        public bool IsAuthenticated(ControllerContext context)
        {
            throw new NotImplementedException();
        }

        public void RedirectToLogin(ControllerContext context)
        {
            throw new NotImplementedException();
        }

        public void SetAuthCookie(string userName, bool createPersistentCookie)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
