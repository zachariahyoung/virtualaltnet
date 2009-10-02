﻿using System;
using System.Collections.Generic;
using System.ServiceModel.Syndication;
using System.Web.Mvc;
using MvcContrib.Filters;
using SharpArch.Core;
using SharpArch.Core.PersistenceSupport;
using van.ApplicationServices;
using van.Core.Dto;
using van.Core;

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
        public ActionResult Index()
        {
            PostEventRecordViewModel viewModel = PostEventRecordViewModel.CreatePostEventRecordViewModel(aggregator);

            return View(viewModel);
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
