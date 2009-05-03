using System.Web.Mvc;

namespace van.Web.Controllers
{
    [HandleError]
    public class AboutController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
