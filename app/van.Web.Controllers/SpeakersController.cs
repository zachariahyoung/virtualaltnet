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
    public class SpeakersController : Controller
    {
        public SpeakersController(IRepository<Speaker> speakerRepository) {
            Check.Require(speakerRepository != null, "speakerRepository may not be null");

            this.speakerRepository = speakerRepository;
        }

        [Transaction]
        public ActionResult Index() {
            IList<Speaker> speakers = speakerRepository.GetAll();
            return View(speakers);
        }

        [Transaction]
        public ActionResult Show(int id) {
            Speaker speaker = speakerRepository.Get(id);
            return View(speaker);
        }

        public ActionResult Create() {
            SpeakerFormViewModel viewModel = SpeakerFormViewModel.CreateSpeakerFormViewModel();
            return View(viewModel);
        }

        [ValidateAntiForgeryToken]
        [Transaction]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(Speaker speaker) {
            if (ViewData.ModelState.IsValid && speaker.IsValid()) {
                speakerRepository.SaveOrUpdate(speaker);

                TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()] = 
					"The speaker was successfully created.";
                return RedirectToAction("Index");
            }

            SpeakerFormViewModel viewModel = SpeakerFormViewModel.CreateSpeakerFormViewModel();
            viewModel.Speaker = speaker;
            return View(viewModel);
        }

        [Transaction]
        public ActionResult Edit(int id) {
            SpeakerFormViewModel viewModel = SpeakerFormViewModel.CreateSpeakerFormViewModel();
            viewModel.Speaker = speakerRepository.Get(id);
            return View(viewModel);
        }

        [ValidateAntiForgeryToken]
        [Transaction]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(Speaker speaker) {
            Speaker speakerToUpdate = speakerRepository.Get(speaker.Id);
            TransferFormValuesTo(speakerToUpdate, speaker);

            if (ViewData.ModelState.IsValid && speaker.IsValid()) {
                TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()] = 
					"The speaker was successfully updated.";
                return RedirectToAction("Index");
            }
            else {
                speakerRepository.DbContext.RollbackTransaction();

				SpeakerFormViewModel viewModel = SpeakerFormViewModel.CreateSpeakerFormViewModel();
				viewModel.Speaker = speaker;
				return View(viewModel);
            }
        }

        private void TransferFormValuesTo(Speaker speakerToUpdate, Speaker speakerFromForm) {
			speakerToUpdate.FirstName = speakerFromForm.FirstName;
			speakerToUpdate.LastName = speakerFromForm.LastName;
			speakerToUpdate.Email = speakerFromForm.Email;
			speakerToUpdate.Website = speakerFromForm.Website;
			speakerToUpdate.Presentation = speakerFromForm.Presentation;
        }

        [ValidateAntiForgeryToken]
        [Transaction]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete(int id) {
            string resultMessage = "The speaker was successfully deleted.";
            Speaker speakerToDelete = speakerRepository.Get(id);

            if (speakerToDelete != null) {
                speakerRepository.Delete(speakerToDelete);

                try {
                    speakerRepository.DbContext.CommitChanges();
                }
                catch {
                    resultMessage = "A problem was encountered preventing the speaker from being deleted. " +
						"Another item likely depends on this speaker.";
                    speakerRepository.DbContext.RollbackTransaction();
                }
            }
            else {
                resultMessage = "The speaker could not be found for deletion. It may already have been deleted.";
            }

            TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()] = resultMessage;
            return RedirectToAction("Index");
        }

		/// <summary>
		/// Holds data to be passed to the Speaker form for creates and edits
		/// </summary>
        public class SpeakerFormViewModel
        {
            private SpeakerFormViewModel() { }

			/// <summary>
			/// Creation method for creating the view model. Services may be passed to the creation 
			/// method to instantiate items such as lists for drop down boxes.
			/// </summary>
            public static SpeakerFormViewModel CreateSpeakerFormViewModel() {
                SpeakerFormViewModel viewModel = new SpeakerFormViewModel();
                
                return viewModel;
            }

            public Speaker Speaker { get; internal set; }
        }

        private readonly IRepository<Speaker> speakerRepository;
    }
}
