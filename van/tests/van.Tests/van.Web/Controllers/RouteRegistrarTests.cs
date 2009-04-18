using NUnit.Framework;
using van.Web.Controllers;
using MvcContrib.TestHelper;
using System.Web.Routing;

namespace Tests.van.Web.Controllers
{
    [TestFixture]
    public class RouteRegistrarTests
    {
        [SetUp]
        public void SetUp()
        {
            RouteTable.Routes.Clear();
            RouteRegistrar.RegisterRoutesTo(RouteTable.Routes);
        }

        [Test]
        public void CanVerifyHomeRouteMaps()
        {
            "~/".Route().ShouldMapTo<HomeController>(x => x.Index());
        }

    }
}