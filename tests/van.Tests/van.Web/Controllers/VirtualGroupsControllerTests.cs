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
    public class VirtualGroupsControllerTests
    {
        [SetUp]
        public void SetUp() {
            ServiceLocatorInitializer.Init();
            controller = new VirtualGroupsController(CreateMockVirtualGroupRepository());
        }

        /// <summary>
        /// Add a couple of objects to the list within CreateVirtualGroups and change the 
        /// "ShouldEqual(0)" within this test to the respective number.
        /// </summary>
        [Test]
        public void CanListVirtualGroups() {
            ViewResult result = controller.Index().AssertViewRendered();

            result.ViewData.Model.ShouldNotBeNull();
            (result.ViewData.Model as List<VirtualGroup>).Count.ShouldEqual(0);
        }

        [Test]
        public void CanShowVirtualGroup() {
            ViewResult result = controller.Show(1).AssertViewRendered();

			result.ViewData.ShouldNotBeNull();
			
            (result.ViewData.Model as VirtualGroup).Id.ShouldEqual(1);
        }

        [Test]
        public void CanInitVirtualGroupCreation() {
            ViewResult result = controller.Create().AssertViewRendered();
            
            result.ViewData.Model.ShouldNotBeNull();
            result.ViewData.Model.ShouldBeOfType(typeof(VirtualGroupsController.VirtualGroupFormViewModel));
            (result.ViewData.Model as VirtualGroupsController.VirtualGroupFormViewModel).VirtualGroup.ShouldBeNull();
        }

        [Test]
        public void CanEnsureVirtualGroupCreationIsValid() {
            VirtualGroup virtualGroupFromForm = new VirtualGroup();
            ViewResult result = controller.Create(virtualGroupFromForm).AssertViewRendered();

            result.ViewData.Model.ShouldNotBeNull();
            result.ViewData.Model.ShouldBeOfType(typeof(VirtualGroupsController.VirtualGroupFormViewModel));
        }

        [Test]
        public void CanCreateVirtualGroup() {
            VirtualGroup virtualGroupFromForm = CreateTransientVirtualGroup();
            RedirectToRouteResult redirectResult = controller.Create(virtualGroupFromForm)
                .AssertActionRedirect().ToAction("Index");
            controller.TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()].ToString()
				.ShouldContain("was successfully created");
        }

        [Test]
        public void CanUpdateVirtualGroup() {
            VirtualGroup virtualGroupFromForm = CreateTransientVirtualGroup();
            EntityIdSetter.SetIdOf<int>(virtualGroupFromForm, 1);
            RedirectToRouteResult redirectResult = controller.Edit(virtualGroupFromForm)
                .AssertActionRedirect().ToAction("Index");
            controller.TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()].ToString()
				.ShouldContain("was successfully updated");
        }

        [Test]
        public void CanInitVirtualGroupEdit() {
            ViewResult result = controller.Edit(1).AssertViewRendered();

			result.ViewData.Model.ShouldNotBeNull();
            result.ViewData.Model.ShouldBeOfType(typeof(VirtualGroupsController.VirtualGroupFormViewModel));
            (result.ViewData.Model as VirtualGroupsController.VirtualGroupFormViewModel).VirtualGroup.Id.ShouldEqual(1);
        }

        [Test]
        public void CanDeleteVirtualGroup() {
            RedirectToRouteResult redirectResult = controller.Delete(1)
                .AssertActionRedirect().ToAction("Index");
            
            controller.TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()].ToString()
				.ShouldContain("was successfully deleted");
        }

		#region Create Mock VirtualGroup Repository

        private IRepository<VirtualGroup> CreateMockVirtualGroupRepository() {

            IRepository<VirtualGroup> mockedRepository = MockRepository.GenerateMock<IRepository<VirtualGroup>>();
            mockedRepository.Expect(mr => mr.GetAll()).Return(CreateVirtualGroups());
            mockedRepository.Expect(mr => mr.Get(1)).IgnoreArguments().Return(CreateVirtualGroup());
            mockedRepository.Expect(mr => mr.SaveOrUpdate(null)).IgnoreArguments().Return(CreateVirtualGroup());
            mockedRepository.Expect(mr => mr.Delete(null)).IgnoreArguments();

			IDbContext mockedDbContext = MockRepository.GenerateStub<IDbContext>();
			mockedDbContext.Stub(c => c.CommitChanges());
			mockedRepository.Stub(mr => mr.DbContext).Return(mockedDbContext);
            
            return mockedRepository;
        }

        private VirtualGroup CreateVirtualGroup() {
            VirtualGroup virtualGroup = CreateTransientVirtualGroup();
            EntityIdSetter.SetIdOf<int>(virtualGroup, 1);
            return virtualGroup;
        }

        private List<VirtualGroup> CreateVirtualGroups() {
            List<VirtualGroup> virtualGroups = new List<VirtualGroup>();

            // Create a number of domain object instances here and add them to the list

            return virtualGroups;
        }
        
        #endregion

        /// <summary>
        /// Creates a valid, transient VirtualGroup; typical of something retrieved back from a form submission
        /// </summary>
        private VirtualGroup CreateTransientVirtualGroup() {
            VirtualGroup virtualGroup = new VirtualGroup() {
				GroupName = "VAN",
				Website = "http://wwww.virtualaltnet.com",
				Manager = null
            };
            
            return virtualGroup;
        }

        private VirtualGroupsController controller;
    }
}