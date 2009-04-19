
using System.Web.Mvc;
using van.Core.DataInterfaces;

namespace van.Web.Controllers
{
    public class RecordingsController : Controller
    {
        public RecordingsController(
            IRecordingRepository recordingRepository)   {}

        public ActionResult ListRecordingsMatching(string filter)
        {
            return null;
        }
    }
}
