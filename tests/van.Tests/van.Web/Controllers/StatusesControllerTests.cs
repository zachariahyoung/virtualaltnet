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
    public class StatusesControllerTests
    {
        [SetUp]
        public void SetUp() {
            ServiceLocatorInitializer.Init();
            controller = new StatusesController(CreateMockStatusRepository());
        }

        /// <summary>
        /// Add a couple of objects to the list within CreateStatuses and change the 
        /// "ShouldEqual(0)" within this test to the respective number.
        /// </summary>
        [Test]
        public void CanListStatuses() {
            ViewResult result = controller.Index().AssertViewRendered();

            result.ViewData.Model.ShouldNotBeNull();
            (result.ViewData.Model as List<Status>).Count.ShouldEqual(0);
        }

        [Test]
        public void CanShowStatus() {
            ViewResult result = controller.Show(1).AssertViewRendered();

			result.ViewData.ShouldNotBeNull();
			
            (result.ViewData.Model as Status).Id.ShouldEqual(1);
        }

        [Test]
        public void CanInitStatusCreation() {
            ViewResult result = controller.Create().AssertViewRendered();
            
            result.ViewData.Model.ShouldNotBeNull();
            result.ViewData.Model.ShouldBeOfType(typeof(StatusFormViewModel));
            (result.ViewData.Model as StatusFormViewModel).Status.ShouldBeNull();
        }

        [Test]
        public void CanEnsureStatusCreationIsValid() {
            Status statusFromForm = new Status();
            ViewResult result = controller.Create(statusFromForm).AssertViewRendered();

            result.ViewData.Model.ShouldNotBeNull();
            result.ViewData.Model.ShouldBeOfType(typeof(StatusFormViewModel));
        }

        [Test]
        public void CanCreateStatus() {
            Status statusFromForm = CreateTransientStatus();
            RedirectToRouteResult redirectResult = controller.Create(statusFromForm)
                .AssertActionRedirect().ToAction("Index");
            controller.TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()].ToString()
				.ShouldContain("was successfully created");
        }

        [Test]
        public void CanUpdateStatus() {
            Status statusFromForm = CreateTransientStatus();
            EntityIdSetter.SetIdOf<int>(statusFromForm, 1);
            RedirectToRouteResult redirectResult = controller.Edit(statusFromForm)
                .AssertActionRedirect().ToAction("Index");
            controller.TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()].ToString()
				.ShouldContain("was successfully updated");
        }

        [Test]
        public void CanInitStatusEdit() {
            ViewResult result = controller.Edit(1).AssertViewRendered();

			result.ViewData.Model.ShouldNotBeNull();
            result.ViewData.Model.ShouldBeOfType(typeof(StatusFormViewModel));
            (result.ViewData.Model as StatusFormViewModel).Status.Id.ShouldEqual(1);
        }

        [Test]
        public void CanDeleteStatus() {
            RedirectToRouteResult redirectResult = controller.Delete(1)
                .AssertActionRedirect().ToAction("Index");
            
            controller.TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()].ToString()
				.ShouldContain("was successfully deleted");
        }

		#region Create Mock Status Repository

        private IStatusManagementService CreateMockStatusRepository()
        {

            IStatusManagementService mockedRepository = MockRepository.GenerateMock<IStatusManagementService>();
            mockedRepository.Expect(mr => mr.GetAll()).Return(CreateStatuses());
            mockedRepository.Expect(mr => mr.Get(1)).IgnoreArguments().Return(CreateStatus());

			IDbContext mockedDbContext = MockRepository.GenerateStub<IDbContext>();
			mockedDbContext.Stub(c => c.CommitChanges());
            
            return mockedRepository;
        }

        private Status CreateStatus() {
            Status status = CreateTransientStatus();
            EntityIdSetter.SetIdOf<int>(status, 1);
            return status;
        }

        private List<Status> CreateStatuses() {
            List<Status> statuses = new List<Status>();

            // Create a number of domain object instances here and add them to the list

            return statuses;
        }
        
        #endregion

        /// <summary>
        /// Creates a valid, transient Status; typical of something retrieved back from a form submission
        /// </summary>
        private Status CreateTransientStatus() {
            Status status = new Status() {
				Name = "Active"
            };
            
            return status;
        }

        private StatusesController controller;
    }
}
