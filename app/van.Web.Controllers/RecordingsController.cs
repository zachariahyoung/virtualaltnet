using System.Web.Mvc;
using van.Core;
using SharpArch.Core.PersistenceSupport;
using System.Collections.Generic;
using SharpArch.Web.NHibernate;
using SharpArch.Core;
using van.Web.Controllers.Infrastructure;

namespace van.Web.Controllers
{
    [HandleErrorAttribute]

    public class RecordingsController : Controller

    {
        public RecordingsController(IRepository<Recording> recordingRepository) {
            Check.Require(recordingRepository != null, "recordingRepository may not be null");

            this.recordingRepository = recordingRepository;
        }

        [Transaction]
        public ActionResult Index() {
            IList<Recording> recordings = recordingRepository.GetAll();
            return View(recordings);
        }

        [Transaction]
        public ActionResult Show(int id) {
            Recording recording = recordingRepository.Get(id);
            return View(recording);
        }
        
        [RequiresAuthentication]
        [RequiresAuthorization (RoleToCheckFor="Administrator")]
        public ActionResult Create() {
            RecordingFormViewModel viewModel = RecordingFormViewModel.CreateRecordingFormViewModel();
            return View(viewModel);
        }
        [RequiresAuthentication]
        [RequiresAuthorization(RoleToCheckFor = "Administrator")]
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
            return View(viewModel);
        }
        [RequiresAuthentication]
        [RequiresAuthorization(RoleToCheckFor = "Administrator")]
        [Transaction]
        public ActionResult Edit(int id) {
            RecordingFormViewModel viewModel = RecordingFormViewModel.CreateRecordingFormViewModel();
            viewModel.Recording = recordingRepository.Get(id);
            return View(viewModel);
        }
        [RequiresAuthentication]
        [RequiresAuthorization(RoleToCheckFor = "Administrator")]
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

        private void TransferFormValuesTo(Recording recordingToUpdate, Recording recordingFromForm) {
			recordingToUpdate.Title = recordingFromForm.Title;
			recordingToUpdate.Url = recordingFromForm.Url;
			recordingToUpdate.Date = recordingFromForm.Date;
			recordingToUpdate.Duration = recordingFromForm.Duration;
            recordingToUpdate.Speaker = recordingFromForm.Speaker;
            recordingToUpdate.UserGroup = recordingFromForm.UserGroup;
            recordingToUpdate.LiveMeetingUrl = recordingFromForm.LiveMeetingUrl;
            recordingToUpdate.Description = recordingFromForm.Description;
        }
        [RequiresAuthentication]
        [RequiresAuthorization(RoleToCheckFor = "Administrator")]
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

        private readonly IRepository<Recording> recordingRepository;
    }
}
