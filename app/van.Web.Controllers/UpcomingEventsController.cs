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
    public class UpcomingEventsController : Controller
    {
        public UpcomingEventsController(IRepository<UpcomingEvent> upcomingEventRepository) {
            Check.Require(upcomingEventRepository != null, "upcomingEventRepository may not be null");

            this.upcomingEventRepository = upcomingEventRepository;
        }

        [Transaction]
        public ActionResult Index() {
            IList<UpcomingEvent> upcomingEvents = upcomingEventRepository.GetAll();
            return View(upcomingEvents);
        }

        [Transaction]
        public ActionResult Show(int id) {
            UpcomingEvent upcomingEvent = upcomingEventRepository.Get(id);
            return View(upcomingEvent);
        }

        public ActionResult Create() {
            UpcomingEventFormViewModel viewModel = UpcomingEventFormViewModel.CreateUpcomingEventFormViewModel();
            return View(viewModel);
        }

        [ValidateAntiForgeryToken]
        [Transaction]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(UpcomingEvent upcomingEvent) {
            if (ViewData.ModelState.IsValid && upcomingEvent.IsValid()) {
                upcomingEventRepository.SaveOrUpdate(upcomingEvent);

                TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()] = 
					"The upcomingEvent was successfully created.";
                return RedirectToAction("Index");
            }

            UpcomingEventFormViewModel viewModel = UpcomingEventFormViewModel.CreateUpcomingEventFormViewModel();
            viewModel.UpcomingEvent = upcomingEvent;
            return View(viewModel);
        }

        [Transaction]
        public ActionResult Edit(int id) {
            UpcomingEventFormViewModel viewModel = UpcomingEventFormViewModel.CreateUpcomingEventFormViewModel();
            viewModel.UpcomingEvent = upcomingEventRepository.Get(id);
            return View(viewModel);
        }

        [ValidateAntiForgeryToken]
        [Transaction]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(UpcomingEvent upcomingEvent) {
            UpcomingEvent upcomingEventToUpdate = upcomingEventRepository.Get(upcomingEvent.Id);
            TransferFormValuesTo(upcomingEventToUpdate, upcomingEvent);

            if (ViewData.ModelState.IsValid && upcomingEvent.IsValid()) {
                TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()] = 
					"The upcomingEvent was successfully updated.";
                return RedirectToAction("Index");
            }
            else {
                upcomingEventRepository.DbContext.RollbackTransaction();

				UpcomingEventFormViewModel viewModel = UpcomingEventFormViewModel.CreateUpcomingEventFormViewModel();
				viewModel.UpcomingEvent = upcomingEvent;
				return View(viewModel);
            }
        }

        private void TransferFormValuesTo(UpcomingEvent upcomingEventToUpdate, UpcomingEvent upcomingEventFromForm) {
			upcomingEventToUpdate.Title = upcomingEventFromForm.Title;
			upcomingEventToUpdate.EventDate = upcomingEventFromForm.EventDate;
			upcomingEventToUpdate.FullDescription = upcomingEventFromForm.FullDescription;
			upcomingEventToUpdate.ShortDescription = upcomingEventFromForm.ShortDescription;
			upcomingEventToUpdate.Presenter = upcomingEventFromForm.Presenter;
			upcomingEventToUpdate.Approved = upcomingEventFromForm.Approved;
        }

        [ValidateAntiForgeryToken]
        [Transaction]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete(int id) {
            string resultMessage = "The upcomingEvent was successfully deleted.";
            UpcomingEvent upcomingEventToDelete = upcomingEventRepository.Get(id);

            if (upcomingEventToDelete != null) {
                upcomingEventRepository.Delete(upcomingEventToDelete);

                try {
                    upcomingEventRepository.DbContext.CommitChanges();
                }
                catch {
                    resultMessage = "A problem was encountered preventing the upcomingEvent from being deleted. " +
						"Another item likely depends on this upcomingEvent.";
                    upcomingEventRepository.DbContext.RollbackTransaction();
                }
            }
            else {
                resultMessage = "The upcomingEvent could not be found for deletion. It may already have been deleted.";
            }

            TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()] = resultMessage;
            return RedirectToAction("Index");
        }

		/// <summary>
		/// Holds data to be passed to the UpcomingEvent form for creates and edits
		/// </summary>
        public class UpcomingEventFormViewModel
        {
            private UpcomingEventFormViewModel() { }

			/// <summary>
			/// Creation method for creating the view model. Services may be passed to the creation 
			/// method to instantiate items such as lists for drop down boxes.
			/// </summary>
            public static UpcomingEventFormViewModel CreateUpcomingEventFormViewModel() {
                UpcomingEventFormViewModel viewModel = new UpcomingEventFormViewModel();
                
                return viewModel;
            }

            public UpcomingEvent UpcomingEvent { get; internal set; }
        }

        private readonly IRepository<UpcomingEvent> upcomingEventRepository;
    }
}
