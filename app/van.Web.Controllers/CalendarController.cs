using System.Web.Mvc;

namespace van.Web.Controllers
{
    [HandleError]
    public class CalendarController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
