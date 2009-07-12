using System.Collections.Generic;
using System.ServiceModel.Syndication;
using System.Web.Mvc;
using SharpArch.Core;
using van.ApplicationServices;

namespace van.Web.Controllers
{
    [HandleErrorAttribute]
    public class HomeController : Controller
    {
        public HomeController(IRssFeedReader rssFeedReader)
        {
            Check.Require(rssFeedReader != null, "rssFeedReader may not be null");

            this.rssFeedReader = rssFeedReader;
        }
       
        public ActionResult Index()
        {
            
            SyndicationFeed item = rssFeedReader.readFeed("http://feeds.feedburner.com/VirtualAltnet?format=xml");

            return View(item);
        }

        public ActionResult Calendar()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public RedirectResult Blog()
        {
            return Redirect("http://feeds2.feedburner.com/VirtualAltnet");
        }

        public RedirectResult GoogleGroup()
        {
            return Redirect("http://groups.google.com/group/virtualaltnet");
        }

        public RedirectResult Twitter()
        {
            return Redirect("http://twitter.com/virtualaltnet");
        }

        private readonly IRssFeedReader rssFeedReader;
    }
}
