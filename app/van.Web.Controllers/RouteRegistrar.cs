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
            routes.CreateArea("Recordings", "van.Web.Controllers",
                routes.MapRoute(null, "Recordings/{controller}/{action}", new { action = "Index" }),
                routes.MapRoute(null, "Recordings/{controller}/{action}/{id}")
            );
            
           // Routing config for the root area
            routes.CreateArea("Root", "van.Web.Controllers", 
                routes.MapRoute(null, "{controller}/{action}", 
                new { controller = "Home", action = "Index" }));
            
        }
    }
}
