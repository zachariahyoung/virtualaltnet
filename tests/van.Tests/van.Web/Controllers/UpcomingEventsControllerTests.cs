using System;
using MvcContrib.TestHelper;
using NUnit.Framework;
using Rhino.Mocks;
using SharpArch.Core.PersistenceSupport;
using SharpArch.Testing;
using SharpArch.Testing.NUnit;
using System.Collections.Generic;
using System.Web.Mvc;
using van.Core;
using van.Web.Controllers;
 

namespace Tests.van.Web.Controllers
{
    [TestFixture]
    public class UpcomingEventsControllerTests
    {
        [SetUp]
        public void SetUp() {
            ServiceLocatorInitializer.Init();
            controller = new UpcomingEventsController(CreateMockUpcomingEventRepository());
        }

        /// <summary>
        /// Add a couple of objects to the list within CreateUpcomingEvents and change the 
        /// "ShouldEqual(0)" within this test to the respective number.
        /// </summary>
        [Test]
        public void CanListUpcomingEvents() {
            ViewResult result = controller.Index().AssertViewRendered();

            result.ViewData.Model.ShouldNotBeNull();
            (result.ViewData.Model as List<UpcomingEvent>).Count.ShouldEqual(0);
        }

        [Test]
        public void CanShowUpcomingEvent() {
            ViewResult result = controller.Show(1).AssertViewRendered();

			result.ViewData.ShouldNotBeNull();
			
            (result.ViewData.Model as UpcomingEvent).Id.ShouldEqual(1);
        }

        [Test]
        public void CanInitUpcomingEventCreation() {
            ViewResult result = controller.Create().AssertViewRendered();
            
            result.ViewData.Model.ShouldNotBeNull();
            result.ViewData.Model.ShouldBeOfType(typeof(UpcomingEventsController.UpcomingEventFormViewModel));
            (result.ViewData.Model as UpcomingEventsController.UpcomingEventFormViewModel).UpcomingEvent.ShouldBeNull();
        }

        [Test]
        public void CanEnsureUpcomingEventCreationIsValid() {
            UpcomingEvent upcomingEventFromForm = new UpcomingEvent();
            ViewResult result = controller.Create(upcomingEventFromForm).AssertViewRendered();

            result.ViewData.Model.ShouldNotBeNull();
            result.ViewData.Model.ShouldBeOfType(typeof(UpcomingEventsController.UpcomingEventFormViewModel));
        }

        [Test]
        public void CanCreateUpcomingEvent() {
            UpcomingEvent upcomingEventFromForm = CreateTransientUpcomingEvent();
            RedirectToRouteResult redirectResult = controller.Create(upcomingEventFromForm)
                .AssertActionRedirect().ToAction("Index");
            controller.TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()].ToString()
				.ShouldContain("was successfully created");
        }

        [Test]
        public void CanUpdateUpcomingEvent() {
            UpcomingEvent upcomingEventFromForm = CreateTransientUpcomingEvent();
            EntityIdSetter.SetIdOf<int>(upcomingEventFromForm, 1);
            RedirectToRouteResult redirectResult = controller.Edit(upcomingEventFromForm)
                .AssertActionRedirect().ToAction("Index");
            controller.TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()].ToString()
				.ShouldContain("was successfully updated");
        }

        [Test]
        public void CanInitUpcomingEventEdit() {
            ViewResult result = controller.Edit(1).AssertViewRendered();

			result.ViewData.Model.ShouldNotBeNull();
            result.ViewData.Model.ShouldBeOfType(typeof(UpcomingEventsController.UpcomingEventFormViewModel));
            (result.ViewData.Model as UpcomingEventsController.UpcomingEventFormViewModel).UpcomingEvent.Id.ShouldEqual(1);
        }

        [Test]
        public void CanDeleteUpcomingEvent() {
            RedirectToRouteResult redirectResult = controller.Delete(1)
                .AssertActionRedirect().ToAction("Index");
            
            controller.TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()].ToString()
				.ShouldContain("was successfully deleted");
        }

		#region Create Mock UpcomingEvent Repository

        private IRepository<UpcomingEvent> CreateMockUpcomingEventRepository() {

            IRepository<UpcomingEvent> mockedRepository = MockRepository.GenerateMock<IRepository<UpcomingEvent>>();
            mockedRepository.Expect(mr => mr.GetAll()).Return(CreateUpcomingEvents());
            mockedRepository.Expect(mr => mr.Get(1)).IgnoreArguments().Return(CreateUpcomingEvent());
            mockedRepository.Expect(mr => mr.SaveOrUpdate(null)).IgnoreArguments().Return(CreateUpcomingEvent());
            mockedRepository.Expect(mr => mr.Delete(null)).IgnoreArguments();

			IDbContext mockedDbContext = MockRepository.GenerateStub<IDbContext>();
			mockedDbContext.Stub(c => c.CommitChanges());
			mockedRepository.Stub(mr => mr.DbContext).Return(mockedDbContext);
            
            return mockedRepository;
        }

        private UpcomingEvent CreateUpcomingEvent() {
            UpcomingEvent upcomingEvent = CreateTransientUpcomingEvent();
            EntityIdSetter.SetIdOf<int>(upcomingEvent, 1);
            return upcomingEvent;
        }

        private List<UpcomingEvent> CreateUpcomingEvents() {
            List<UpcomingEvent> upcomingEvents = new List<UpcomingEvent>();

            // Create a number of domain object instances here and add them to the list

            return upcomingEvents;
        }
        
        #endregion

        /// <summary>
        /// Creates a valid, transient UpcomingEvent; typical of something retrieved back from a form submission
        /// </summary>
        private UpcomingEvent CreateTransientUpcomingEvent() {
            UpcomingEvent upcomingEvent = new UpcomingEvent() {
				Title = "A night with Groucho Marx",
				EventDate = DateTime.Parse("01/26/2010"),
				FullDescription = "Long description that will form blog post entry.",
				ShortDescription = "Short description that is used in summary view.",
				Presenter = null,
				Approved = false
            };
            
            return upcomingEvent;
        }

        private UpcomingEventsController controller;
    }
}
