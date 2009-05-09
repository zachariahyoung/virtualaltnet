using System.Web.Mvc;
using SharpArch.Core.PersistenceSupport;
using van.Core;
using SharpArch.Web.NHibernate;
using SharpArch.Core;

namespace van.Web.Controllers
{
    [HandleError]
    public class RecordingsController : Controller
    {

        private readonly IRepository<Recording> recordingRepository;

        public RecordingsController(IRepository<Recording> recordingRepository) {
            Check.Require(recordingRepository != null, "recordingRepository may not be null");

            this.recordingRepository = recordingRepository;
        }

        [Transaction]
        public ActionResult Index() {
            var recordings = recordingRepository.GetAll();
            return View(recordings);
        }

        [Transaction]
        public ActionResult Show(int id) {
            Recording recording = recordingRepository.Get(id);
            return View(recording);
        }

        public ActionResult Create() {
            RecordingFormViewModel viewModel = RecordingFormViewModel.CreateRecordingFormViewModel();
            return View(viewModel);
        }

        [ValidateAntiForgeryToken]
        [Transaction]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(Recording recording) {
            if (ViewData.ModelState.IsValid && recording.IsValid()) {
                recordingRepository.SaveOrUpdate(recording);

                TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()] = 
					"The recording was successfully created.";
                return RedirectToAction("Index");
            }

            RecordingFormViewModel viewModel = RecordingFormViewModel.CreateRecordingFormViewModel();
            viewModel.Recording = recording;
            return RedirectToAction("Index");
        }

        [Transaction]
        public ActionResult Edit(int id) {
            RecordingFormViewModel viewModel = RecordingFormViewModel.CreateRecordingFormViewModel();
            viewModel.Recording = recordingRepository.Get(id);
            return View(viewModel);
        }

        [ValidateAntiForgeryToken]
        [Transaction]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(Recording recording) {
            Recording recordingToUpdate = recordingRepository.Get(recording.Id);
            TransferFormValuesTo(recordingToUpdate, recording);

            if (ViewData.ModelState.IsValid && recording.IsValid()) {
                TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()] = 
					"The recording was successfully updated.";
                return RedirectToAction("Index");
            }
            else {
                recordingRepository.DbContext.RollbackTransaction();

				RecordingFormViewModel viewModel = RecordingFormViewModel.CreateRecordingFormViewModel();
				viewModel.Recording = recording;
				return View(viewModel);
            }
        }

        private static void TransferFormValuesTo(Recording recordingToUpdate, Recording recordingFromForm) {
			recordingToUpdate.RecordingTitle = recordingFromForm.RecordingTitle;
			recordingToUpdate.RecordingUrl = recordingFromForm.RecordingUrl;
			recordingToUpdate.RecordingDate = recordingFromForm.RecordingDate;
			recordingToUpdate.RecordingDuration = recordingFromForm.RecordingDuration;
        }

        [ValidateAntiForgeryToken]
        [Transaction]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete(int id) {
            string resultMessage = "The recording was successfully deleted.";
            Recording recordingToDelete = recordingRepository.Get(id);

            if (recordingToDelete != null) {
                recordingRepository.Delete(recordingToDelete);

                try {
                    recordingRepository.DbContext.CommitChanges();
                }
                catch {
                    resultMessage = "A problem was encountered preventing the recording from being deleted. " +
						"Another item likely depends on this recording.";
                    recordingRepository.DbContext.RollbackTransaction();
                }
            }
            else {
                resultMessage = "The recording could not be found for deletion. It may already have been deleted.";
            }

            TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()] = resultMessage;
            return RedirectToAction("Index");
        }

		/// <summary>
		/// Holds data to be passed to the Recording form for creates and edits
		/// </summary>
        public class RecordingFormViewModel
        {
            private RecordingFormViewModel() { }

			/// <summary>
			/// Creation method for creating the view model. Services may be passed to the creation 
			/// method to instantiate items such as lists for drop down boxes.
			/// </summary>
            public static RecordingFormViewModel CreateRecordingFormViewModel() {
                var viewModel = new RecordingFormViewModel();
                
                return viewModel;
            }

            public Recording Recording { get; internal set; }
        }

       
    }
}
