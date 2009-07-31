using System;
using System.Web.Mvc;

namespace van.Web.Extensions
{
    public static class IsCurrentActionHelper
    {

        public static string CurrentAction(this HtmlHelper helper, string actionName, string controllerName) {
            var currentControllerName = (string)helper.ViewContext.RouteData.Values["controller"];
            var currentActionName = (string)helper.ViewContext.RouteData.Values["action"];

            if (currentControllerName.Equals(controllerName, StringComparison.CurrentCultureIgnoreCase) && currentActionName.Equals(actionName, StringComparison.CurrentCultureIgnoreCase))
                return "active";
            return null;
        }
    }
}