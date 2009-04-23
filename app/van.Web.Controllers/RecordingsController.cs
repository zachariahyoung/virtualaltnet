using System.Web.Mvc;
using SharpArch.Web.NHibernate;
using van.Core.DataInterfaces;
using SharpArch.Core;
using van.Core;
using System.Collections.Generic;


namespace van.Web.Controllers
{
    [HandleError]
    public class RecordingsController : Controller
    {
        private readonly IRecordingRepository recordingRepository;

        public RecordingsController(IRecordingRepository recordingRepository)
        {
            Check.Require(recordingRepository != null, "recordingRepository may not be null");

            this.recordingRepository = recordingRepository;
        }

        [Transaction]
        public ActionResult ListRecordingsMatching(string filter)
        {
            List<Recording> matchingRecording = recordingRepository.FindAllMatching(filter);

            return View("ListRecordingMatchingFilter", matchingRecording);

        }
        
        [Transaction]
        public ActionResult Index()
        {
            IList<Recording> recordings = recordingRepository.GetAll();
            return View(recordings);

        }
    }
}
