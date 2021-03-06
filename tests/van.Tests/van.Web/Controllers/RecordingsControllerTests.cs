using System;
using MvcContrib.TestHelper;
using NUnit.Framework;
using Rhino.Mocks;
using SharpArch.Core.PersistenceSupport;
using SharpArch.Testing;
using SharpArch.Testing.NUnit;
using System.Collections.Generic;
using System.Web.Mvc;
using van.ApplicationServices.ManagementService;
using van.ApplicationServices.ViewModels;
using van.Core;
using van.Web.Controllers;

 

namespace Tests.van.Web.Controllers
{
    [TestFixture]
    public class RecordingsControllerTests
    {
        [SetUp]
        public void SetUp() {
            ServiceLocatorInitializer.Init();
            controller = new RecordingsController(CreateMockRecordingRepository());
        }

        /// <summary>
        /// Add a couple of objects to the list within CreateRecordings and change the 
        /// "Is.EqualTo(0)" within this test to the respective number.
        /// </summary>
        [Test]
        public void CanListRecordings() {
            ViewResult result = controller.Index().AssertViewRendered();

            result.ViewData.Model.ShouldNotBeNull();
            (result.ViewData.Model as List<Recording>).Count.ShouldEqual(0);
        }

        [Test]
        public void CanShowRecording() {
            ViewResult result = controller.Show(1).AssertViewRendered();

			result.ViewData.ShouldNotBeNull();
			
            (result.ViewData.Model as Recording).Id.ShouldEqual(1);
        }

        [Test]
        public void CanInitRecordingCreation() {
            ViewResult result = controller.Create().AssertViewRendered();
            
            result.ViewData.Model.ShouldNotBeNull();
            result.ViewData.Model.ShouldBeOfType(typeof(RecordingFormViewModel));
            (result.ViewData.Model as RecordingFormViewModel).Recording.ShouldBeNull();
        }

        [Test]
        public void CanEnsureRecordingCreationIsValid() {
            Recording recordingFromForm = new Recording();
            ViewResult result = controller.Create(recordingFromForm).AssertViewRendered();

            result.ViewData.Model.ShouldNotBeNull();
            result.ViewData.Model.ShouldBeOfType(typeof(RecordingFormViewModel));
        }

        [Test]
        public void CanCreateRecording() {
            Recording recordingFromForm = CreateTransientRecording();
            RedirectToRouteResult redirectResult = controller.Create(recordingFromForm)
                .AssertActionRedirect().ToAction("Index");
            controller.TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()].ToString()
				.ShouldContain("was successfully created");
        }

        [Test]
        public void CanUpdateRecording() {
            Recording recordingFromForm = CreateTransientRecording();
            EntityIdSetter.SetIdOf<int>(recordingFromForm, 1);
            RedirectToRouteResult redirectResult = controller.Edit(recordingFromForm)
                .AssertActionRedirect().ToAction("Index");
            controller.TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()].ToString()
				.ShouldContain("was successfully updated");
        }

        [Test]
        public void CanInitRecordingEdit() {
            ViewResult result = controller.Edit(1).AssertViewRendered();

			result.ViewData.Model.ShouldNotBeNull();
            result.ViewData.Model.ShouldBeOfType(typeof(RecordingFormViewModel));
            (result.ViewData.Model as RecordingFormViewModel).Recording.Id.ShouldEqual(1);
        }

        [Test]
        public void CanDeleteRecording() {
            RedirectToRouteResult redirectResult = controller.Delete(1)
                .AssertActionRedirect().ToAction("Index");
            
            controller.TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()].ToString()
				.ShouldContain("was successfully deleted");
        }

		#region Create Mock Recording Repository

        private IRecordingManagementService CreateMockRecordingRepository()
        {

            IRecordingManagementService mockedRepository = MockRepository.GenerateMock<IRecordingManagementService>();
            mockedRepository.Expect(mr => mr.GetAll()).Return(CreateRecordings());
            mockedRepository.Expect(mr => mr.Get(1)).IgnoreArguments().Return(CreateRecording());

			IDbContext mockedDbContext = MockRepository.GenerateStub<IDbContext>();
			mockedDbContext.Stub(c => c.CommitChanges());
            
            return mockedRepository;
        }

        private Recording CreateRecording() {
            Recording recording = CreateTransientRecording();
            EntityIdSetter.SetIdOf<int>(recording, 1);
            return recording;
        }

        private List<Recording> CreateRecordings() {
            List<Recording> recordings = new List<Recording>();

            // Create a number of domain object instances here and add them to the list

            return recordings;
        }
        
        #endregion

        /// <summary>
        /// Creates a valid, transient Recording; typical of something retrieved back from a form submission
        /// </summary>
        private Recording CreateTransientRecording() {
            Recording recording = new Recording() {
				Date = DateTime.Parse("01/27/2010"),
                Url = "http://www.viddler.com/explore/virtualaltnet/videos/1",
                LiveMeetingUrl = "http://www.viddler.com/explore/virtualaltnet/videos/1"
            };
            
            return recording;
        }

        private RecordingsController controller;
    }
}
