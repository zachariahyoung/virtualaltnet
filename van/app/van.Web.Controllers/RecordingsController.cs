using System.Web.Mvc;
using SharpArch.Web.NHibernate;
using van.Core.DataInterfaces;
using SharpArch.Core;
using van.Core;
using System.Collections.Generic;


namespace van.Web.Controllers
{
    public class RecordingsController : Controller
    {
        private readonly IRecordingRepository _recordingRepository;

        public RecordingsController(
            IRecordingRepository recordingRepository)
        {
            Check.Require(recordingRepository != null, "_recordingRepository may not be null");

            this._recordingRepository = recordingRepository;
        }

        [Transaction]
        public ActionResult ListRecordingsMatching(string filter)
        {
            List<Recording> matchingRecording = _recordingRepository.FindAllMatching(filter);

            return View("ListRecordingMatchingFilter", matchingRecording);

        }
        
        [Transaction]
        public ActionResult Index()
        {
            IList<Recording> recordings = _recordingRepository.GetAll();
            return View(recordings);

        }
    }
}
