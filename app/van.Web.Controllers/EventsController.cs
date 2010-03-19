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
using van.Web.Controllers.Infrastructure;
using van.Web.Core;

namespace van.Web.Controllers
{
    [HandleError]
    public class EventsController : Controller
    {
        public EventsController(IRepository<Event> eventRepository) {
            Check.Require(eventRepository != null, "eventRepository may not be null");

            this.eventRepository = eventRepository;
        }

        [RequiresAuthentication]
        [RequiresAuthorization(RoleToCheckFor = "Administrator")]
        [Transaction]
        [ResourceFilter(1)]
        public ActionResult Index() {

            var model = new EventsViewModel()
            {
                Events = eventRepository.GetAll()
            };

            return View(model);
        }

        [RequiresAuthentication]
        [RequiresAuthorization(RoleToCheckFor = "Administrator")]
        [Transaction]
        [ResourceFilter(1)]
        public ActionResult Show(int id) {
            
            var model = new EventsViewModel()
            {
                SingleEvent = eventRepository.Get(id)
            };

            return View(model);
        }

        [RequiresAuthentication]
        [RequiresAuthorization(RoleToCheckFor = "Administrator")]
        [ResourceFilter(1)]
        public ActionResult Create() {
            EventFormViewModel viewModel = EventFormViewModel.CreateEventFormViewModel();
            return View(viewModel);
        }

        [RequiresAuthentication]
        [RequiresAuthorization(RoleToCheckFor = "Administrator")]
        [ValidateAntiForgeryToken]
        [Transaction]
        [AcceptVerbs(HttpVerbs.Post)]
        [ResourceFilter(1)]
        public ActionResult Create(Event @event)
        {
            if (ViewData.ModelState.IsValid && @event.IsValid()) {
                eventRepository.SaveOrUpdate(@event);

                TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()] = 
					"The event was successfully created.";
                return RedirectToAction("Index");
            }

            EventFormViewModel viewModel = EventFormViewModel.CreateEventFormViewModel();
            viewModel.UpcomingEvent = @event;
            return View(viewModel);
        }

        [RequiresAuthentication]
        [RequiresAuthorization(RoleToCheckFor = "Administrator")]
        [Transaction]
        [ResourceFilter(1)]
        public ActionResult Edit(int id) {
            EventFormViewModel viewModel = EventFormViewModel.CreateEventFormViewModel();
            viewModel.UpcomingEvent = eventRepository.Get(id);
            return View(viewModel);
        }

        [RequiresAuthentication]
        [RequiresAuthorization(RoleToCheckFor = "Administrator")]
        [ValidateAntiForgeryToken]
        [Transaction]
        [AcceptVerbs(HttpVerbs.Post)]
        [ResourceFilter(1)]
        public ActionResult Edit(Event @event) {
            Event upcomingEventToUpdate = eventRepository.Get(@event.Id);
            TransferFormValuesTo(upcomingEventToUpdate, @event);

            if (ViewData.ModelState.IsValid && @event.IsValid()) {
                TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()] = 
					"The event was successfully updated.";
                return RedirectToAction("Index");
            }
            else {
                eventRepository.DbContext.RollbackTransaction();

				EventFormViewModel viewModel = EventFormViewModel.CreateEventFormViewModel();
				viewModel.UpcomingEvent = @event;
				return View(viewModel);
            }
        }

        private void TransferFormValuesTo(Event eventToUpdate, Event eventFromForm) {
			eventToUpdate.Title = eventFromForm.Title;
            eventToUpdate.Description = eventFromForm.Description;
			eventToUpdate.EventDate = eventFromForm.EventDate;
            eventFromForm.Recording = eventFromForm.Recording;
			eventToUpdate.Presenter = eventFromForm.Presenter;
            eventToUpdate.UserGroup = eventFromForm.UserGroup;
			eventToUpdate.Approved = eventFromForm.Approved;
        }

        [RequiresAuthentication]
        [RequiresAuthorization(RoleToCheckFor = "Administrator")]
        [ValidateAntiForgeryToken]
        [Transaction]
        [AcceptVerbs(HttpVerbs.Post)]
        [ResourceFilter(1)]
        public ActionResult Delete(int id) {
            string resultMessage = "The upcomingEvent was successfully deleted.";
            Event upcomingEventToDelete = eventRepository.Get(id);

            if (upcomingEventToDelete != null) {
                eventRepository.Delete(upcomingEventToDelete);

                try {
                    eventRepository.DbContext.CommitChanges();
                }
                catch {
                    resultMessage = "A problem was encountered preventing the upcomingEvent from being deleted. " +
						"Another item likely depends on this upcomingEvent.";
                    eventRepository.DbContext.RollbackTransaction();
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
        public class EventFormViewModel : BaseViewModel
        {
            private EventFormViewModel() { }

			/// <summary>
			/// Creation method for creating the view model. Services may be passed to the creation 
			/// method to instantiate items such as lists for drop down boxes.
			/// </summary>
            public static EventFormViewModel CreateEventFormViewModel() {
                EventFormViewModel viewModel = new EventFormViewModel();
                
                return viewModel;
            }

            public Event UpcomingEvent { get; internal set; }
        }

        private readonly IRepository<Event> eventRepository;
    }
}
