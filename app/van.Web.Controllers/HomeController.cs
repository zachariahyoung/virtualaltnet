using System;
using System.Collections.Generic;
using System.ServiceModel.Syndication;
using System.Web.Mvc;
using MvcContrib.Filters;
using SharpArch.Core;
using van.ApplicationServices;
using van.Core.Dto;
using van.Core;

namespace van.Web.Controllers
{
    [Rescue("DefaultError")]
    public class HomeController : Controller
    {
        public HomeController(IPostProvider postProvider)
        {
            Check.Require(postProvider != null, "postProvider may not be null");

            this.postProvider = postProvider;
        }
       
        public ActionResult Index()
        {

            IEnumerable<SyndicationItem> items = postProvider.GetItems();

            IEnumerable<PostDto> posts = items.FindItemsTop(15);

            return View(posts);
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

        private readonly IPostProvider postProvider;
    }
}
