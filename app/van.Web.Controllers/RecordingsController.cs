using System.Web.Mvc;
using van.Core;
using SharpArch.Core.PersistenceSupport;
using SharpArch.Core.DomainModel;
using System.Collections.Generic;
using System;
using SharpArch.Web.NHibernate;
using NHibernate.Validator.Engine;
using System.Text;
using SharpArch.Web.CommonValidator;
using SharpArch.Core;

namespace van.Web.Controllers
{
    [HandleError]
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

        public ActionResult Create() {
            return View();
        }

        [ValidateAntiForgeryToken]
        [Transaction]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(Recording recording) {
            if (recording.IsValid()) {
                recordingRepository.SaveOrUpdate(recording);

                TempData["message"] = "The recording was successfully created.";
                return RedirectToAction("Index");
            }

            MvcValidationAdapter.TransferValidationMessagesTo(ViewData.ModelState,
                recording.ValidationResults());
            return View();
        }

        [Transaction]
        public ActionResult Edit(int id) {
            Recording recording = recordingRepository.Get(id);
            return View(recording);
        }

        [ValidateAntiForgeryToken]
        [Transaction]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int id, [ModelBinder(typeof(DefaultModelBinder))] Recording recording) {
            Recording recordingToUpdate = recordingRepository.Get(id);
            TransferFormValuesTo(recordingToUpdate, recording);

            if (recordingToUpdate.IsValid()) {
                TempData["message"] = "The recording was successfully updated.";
                return RedirectToAction("Index");
            }
            else {
                recordingRepository.DbContext.RollbackTransaction();
                MvcValidationAdapter.TransferValidationMessagesTo(ViewData.ModelState, 
                    recordingToUpdate.ValidationResults());
                return View(recordingToUpdate);
            }
        }

        private void TransferFormValuesTo(Recording recordingToUpdate, Recording recordingFromForm) {
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

            TempData["Message"] = resultMessage;
            return RedirectToAction("Index");
        }

        private readonly IRepository<Recording> recordingRepository;
    }
}
