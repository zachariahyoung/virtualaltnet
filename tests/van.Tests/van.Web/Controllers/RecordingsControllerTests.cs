using System;
using MvcContrib.TestHelper;
using NUnit.Framework;
using Rhino.Mocks;
using NUnit.Framework.SyntaxHelpers;
using SharpArch.Core.PersistenceSupport;
using SharpArch.Testing;
using System.Collections.Generic;
using System.Web.Mvc;
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

            Assert.That(result.ViewData.Model as IList<Recording>, Is.Not.Null);
            Assert.That((result.ViewData.Model as IList<Recording>).Count, Is.EqualTo(0));
        }

        [Test]
        public void CanShowRecording() {
            ViewResult result = controller.Show(1).AssertViewRendered();

            Assert.That(result.ViewData.Model as Recording, Is.Not.Null);
            Assert.That((result.ViewData.Model as Recording).Id, Is.EqualTo(1));
        }

        [Test]
        public void CanInitRecordingCreation() {
            ViewResult result = controller.Create().AssertViewRendered();

            Assert.That(result.ViewData.Model as Recording, Is.Null);
        }

        [Test]
        public void CanEnsureRecordingCreationIsValid() {
           Recording recordingFromForm = new Recording();
            ViewResult result = controller.Create(recordingFromForm).AssertViewRendered();

            Assert.That(result.ViewData.Model as Recording, Is.Null);
            Assert.That(result.ViewData.ModelState.Count, Is.GreaterThan(0));

            // Example validation message test for lower level testing
            // Assert.That(result.ViewData.ModelState["Recording.Name"].Errors[0].ErrorMessage, Is.Not.Empty);
        }

        [Test]
        public void CanCreateRecording() {
            var recordingFromForm = CreateTransientRecording();
            var redirectResult = controller.Create(recordingFromForm)
                .AssertActionRedirect().ToAction("Index");
            Assert.That(controller.TempData["message"].ToString().Contains("was successfully created"));
        }

        [Test]
        public void CanUpdateRecording() {
            Recording recordingFromForm = CreateTransientRecording();
            RedirectToRouteResult redirectResult = controller.Edit(1, recordingFromForm)
                .AssertActionRedirect().ToAction("Index");
            Assert.That(controller.TempData["message"].ToString().Contains("was successfully updated"));
        }

        [Test]
        public void CanInitRecordingEdit() {
            ViewResult result = controller.Edit(1).AssertViewRendered();

            Assert.That(result.ViewData.Model as Recording, Is.Not.Null);
            Assert.That((result.ViewData.Model as Recording).Id, Is.EqualTo(1));
        }

        [Test]
        public void CanDeleteRecording() {
            RedirectToRouteResult redirectResult = controller.Delete(1)
                .AssertActionRedirect().ToAction("Index");
            Assert.That(controller.TempData["message"].ToString().Contains("was successfully deleted"));
        }

		#region Create Mock Recording Repository

        private IRepository<Recording> CreateMockRecordingRepository() {
            MockRepository mocks = new MockRepository();

            IRepository<Recording> mockedRepository = mocks.StrictMock<IRepository<Recording>>();
            Expect.Call(mockedRepository.GetAll())
                .Return(CreateRecordings());
            Expect.Call(mockedRepository.Get(1)).IgnoreArguments()
                .Return(CreateRecording());
            Expect.Call(mockedRepository.SaveOrUpdate(null)).IgnoreArguments()
                .Return(CreateRecording());
            Expect.Call(delegate { mockedRepository.Delete(null); }).IgnoreArguments();

            IDbContext mockedDbContext = mocks.StrictMock<IDbContext>();
            Expect.Call(delegate { mockedDbContext.CommitChanges(); });
            SetupResult.For(mockedRepository.DbContext).Return(mockedDbContext);
            
            mocks.Replay(mockedRepository);

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
        private static Recording CreateTransientRecording() {
            var recording = new Recording
                                {
				RecordingTitle = "Van Recording",
				RecordingUrl = "Location of Recording",
				RecordingDate = DateTime.Parse("1/1/1975 12:00:00 AM"),
				RecordingDuration = "1.09"
            };
            
            return recording;
        }

        private RecordingsController controller;
    }
}
