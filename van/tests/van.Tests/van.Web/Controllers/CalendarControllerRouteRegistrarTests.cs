using NUnit.Framework;
using van.Web.Controllers;
using MvcContrib.TestHelper;
using System.Web.Routing;

namespace Tests.van.Web.Controllers
{
    [TestFixture]
    public class CalendarControllerRouteRegistrarTests
    {
        [SetUp]
        public void SetUp() {
            RouteTable.Routes.Clear();
            RouteRegistrar.RegisterRoutesTo(RouteTable.Routes);
        }

        // This lack of test noise can be attributed to 3 guys
        // Ben Sherman, Jimmy Bogard for adding the intitial changes to MVC Contrib and 
        // Steve Harman for the lightweight addition to the route testing as seen below. 
        // take close look at the convention of "~/" which we all know is used to get back to the root 
        // folder. This is quite clever! And on the surface DUHHHHHH.... 

        [Test]
        public void CanVerifyCalendarRouteMaps() {
            "~/Calendar".Route().ShouldMapTo<CalendarController>(x => x.Index());
        }
    }
}
