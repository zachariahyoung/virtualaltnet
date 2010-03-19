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
    public class SpeakersControllerTests
    {
        [SetUp]
        public void SetUp() {
            ServiceLocatorInitializer.Init();
            controller = new SpeakersController(CreateMockSpeakerRepository());
        }

        /// <summary>
        /// Add a couple of objects to the list within CreateSpeakers and change the 
        /// "ShouldEqual(0)" within this test to the respective number.
        /// </summary>
        [Test]
        public void CanListSpeakers() {
            ViewResult result = controller.Index().AssertViewRendered();

            result.ViewData.Model.ShouldNotBeNull();
            (result.ViewData.Model as List<Speaker>).Count.ShouldEqual(0);
        }

        [Test]
        public void CanShowSpeaker() {
            ViewResult result = controller.Show(1).AssertViewRendered();

			result.ViewData.ShouldNotBeNull();
			
            (result.ViewData.Model as Speaker).Id.ShouldEqual(1);
        }

        [Test]
        public void CanInitSpeakerCreation() {
            ViewResult result = controller.Create().AssertViewRendered();
            
            result.ViewData.Model.ShouldNotBeNull();
            result.ViewData.Model.ShouldBeOfType(typeof(SpeakersController.SpeakerFormViewModel));
            (result.ViewData.Model as SpeakersController.SpeakerFormViewModel).Speaker.ShouldBeNull();
        }

        [Test]
        public void CanEnsureSpeakerCreationIsValid() {
            Speaker speakerFromForm = new Speaker();
            ViewResult result = controller.Create(speakerFromForm).AssertViewRendered();

            result.ViewData.Model.ShouldNotBeNull();
            result.ViewData.Model.ShouldBeOfType(typeof(SpeakersController.SpeakerFormViewModel));
        }

        [Test]
        public void CanCreateSpeaker() {
            Speaker speakerFromForm = CreateTransientSpeaker();
            RedirectToRouteResult redirectResult = controller.Create(speakerFromForm)
                .AssertActionRedirect().ToAction("Index");
            controller.TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()].ToString()
				.ShouldContain("was successfully created");
        }

        [Test]
        public void CanUpdateSpeaker() {
            Speaker speakerFromForm = CreateTransientSpeaker();
            EntityIdSetter.SetIdOf<int>(speakerFromForm, 1);
            RedirectToRouteResult redirectResult = controller.Edit(speakerFromForm)
                .AssertActionRedirect().ToAction("Index");
            controller.TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()].ToString()
				.ShouldContain("was successfully updated");
        }

        [Test]
        public void CanInitSpeakerEdit() {
            ViewResult result = controller.Edit(1).AssertViewRendered();

			result.ViewData.Model.ShouldNotBeNull();
            result.ViewData.Model.ShouldBeOfType(typeof(SpeakersController.SpeakerFormViewModel));
            (result.ViewData.Model as SpeakersController.SpeakerFormViewModel).Speaker.Id.ShouldEqual(1);
        }

        [Test]
        public void CanDeleteSpeaker() {
            RedirectToRouteResult redirectResult = controller.Delete(1)
                .AssertActionRedirect().ToAction("Index");
            
            controller.TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()].ToString()
				.ShouldContain("was successfully deleted");
        }

		#region Create Mock Speaker Repository

        private IRepository<Speaker> CreateMockSpeakerRepository() {

            IRepository<Speaker> mockedRepository = MockRepository.GenerateMock<IRepository<Speaker>>();
            mockedRepository.Expect(mr => mr.GetAll()).Return(CreateSpeakers());
            mockedRepository.Expect(mr => mr.Get(1)).IgnoreArguments().Return(CreateSpeaker());
            mockedRepository.Expect(mr => mr.SaveOrUpdate(null)).IgnoreArguments().Return(CreateSpeaker());
            mockedRepository.Expect(mr => mr.Delete(null)).IgnoreArguments();

			IDbContext mockedDbContext = MockRepository.GenerateStub<IDbContext>();
			mockedDbContext.Stub(c => c.CommitChanges());
			mockedRepository.Stub(mr => mr.DbContext).Return(mockedDbContext);
            
            return mockedRepository;
        }

        private Speaker CreateSpeaker() {
            Speaker speaker = CreateTransientSpeaker();
            EntityIdSetter.SetIdOf<int>(speaker, 1);
            return speaker;
        }

        private List<Speaker> CreateSpeakers() {
            List<Speaker> speakers = new List<Speaker>();

            // Create a number of domain object instances here and add them to the list

            return speakers;
        }
        
        #endregion

        /// <summary>
        /// Creates a valid, transient Speaker; typical of something retrieved back from a form submission
        /// </summary>
        private Speaker CreateTransientSpeaker() {
            Speaker speaker = new Speaker() {
				Name = "Joe Smith",
				Email = "JoeSmith@gmail.com",
				Website = "http://wwww.joesmith.com",
                Bio = "Hello World"
            };
            
            return speaker;
        }

        private SpeakersController controller;
    }
}
