﻿using System.Web.Mvc;

namespace van.Web.Controllers
{
    [HandleErrorAttribute]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Calendar()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
