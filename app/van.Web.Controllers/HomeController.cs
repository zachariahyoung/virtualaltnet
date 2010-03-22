using System.Web.Mvc;
using SharpArch.Core;
using van.ApplicationServices;
using van.ApplicationServices.ViewModels;
using van.Core;
using van.Web.Core;

namespace van.Web.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public HomeController(IAggregator aggregator)
        {
            Check.Require(aggregator != null, "aggregator may not be null");

            this.aggregator = aggregator;

        }

        [OutputCache(Duration = 30, VaryByParam = "")]
		  [ResourceFilter(1)]
        public ActionResult Index()
        {
            EventNewsFormViewModel viewModel = aggregator.GetEventNews();

            return View(viewModel);
        }

		  [ResourceFilter(1)]
        public ActionResult Calendar()
        {
			  return View(new BaseViewModel());
        }

		  [ResourceFilter(1)]
        public ActionResult About()
        {
            return View(new BaseViewModel());
        }

        public RedirectResult Blog()
        {
            return Redirect("http://feeds2.feedburner.com/VirtualAltnet");
        }

        public RedirectResult GoogleGroup()
        {
            return Redirect("http://groups.google.com/Group/virtualaltnet");
        }

        public RedirectResult Twitter()
        {
            return Redirect("http://twitter.com/virtualaltnet");
        }
        public RedirectResult DiscountAspNet()
        {
            return Redirect("http://www.DiscountASP.net");
        }
        public RedirectResult Ineta()
        {
            return Redirect("http://www.ineta.org/");
        }
        private readonly IAggregator aggregator;
    }
}
