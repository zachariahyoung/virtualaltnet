using System.Web.Mvc;

namespace van.Web.Controllers
{
    [HandleErrorAttribute]
    public class VanController : Controller
    {
        public RedirectResult Index()
        {
            return Redirect("https://www323.livemeeting.com/cc/usergroups/join?id=van&role=attend");
        }

        
    }
}