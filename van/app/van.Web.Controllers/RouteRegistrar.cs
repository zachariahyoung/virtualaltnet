using System.Web.Mvc;
using System.Web.Routing;
using SharpArch.Web.Areas;

namespace van.Web.Controllers
{
    public class RouteRegistrar
    {
        public static void RegisterRoutesTo(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{*favicon}", new { favicon = @"(.*/)?favicon.ico(/.*)?" });

            // The areas below must be registered from greater subareas to fewer;
            // i.e., the root area should be the last area registered

            // Example illustrative routes with a nested area - note that the order of registration is important
            //routes.CreateArea("Organization/Department", "van.Web.Controllers.Organization.Department",
            //    routes.MapRoute(null, "Organization/Department/{controller}/{action}", new { action = "Index" }),
            //    routes.MapRoute(null, "Organization/Department/{controller}/{action}/{id}")
            //);
            //routes.CreateArea("Organization", "van.Web.Controllers.Organization",
            //    routes.MapRoute(null, "Organization/{controller}/{action}", new { action = "Index" }),
            //    routes.MapRoute(null, "Organization/{controller}/{action}/{id}")
            //);

            
            //Route config for the Calendar area
            routes.CreateArea("Calendar", "van.Web.Controllers",
                            routes.MapRoute(null, "Calendar/{action}", new { controller = "Calendar", action = "Index" })
            );

            //Don’t put .aspx inside the curly-bracket parameter names, or into the ‘default’ values, because it isn’t really part of the controller name - it’s just in the URL to satisfy IIS.

            //// Routing config for the Home area
            routes.CreateArea("Home", "van.Web.Controllers",
                routes.MapRoute(null, "{controller}/{action}", new { controller = "Home", action = "Index" })
            );

            // Routing config for the root area
            routes.CreateArea("Root", "van.Web.Controllers",
                routes.MapRoute(null, "{controller}/{action}", new { controller = "Home", action = "Index" })
            );
            
        }
    }
}
