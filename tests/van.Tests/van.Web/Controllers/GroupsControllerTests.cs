using System;
using MvcContrib.TestHelper;
using NUnit.Framework;
using Rhino.Mocks;
using SharpArch.Core.PersistenceSupport;
using SharpArch.Testing;
using SharpArch.Testing.NUnit;
using System.Collections.Generic;
using System.Web.Mvc;
using van.ApplicationServices;
using van.ApplicationServices.ManagementService;
using van.ApplicationServices.ViewModels;
using van.Core;
using van.Web.Controllers;
 

namespace Tests.van.Web.Controllers
{
    [TestFixture]
    public class GroupsControllerTests
    {
        [SetUp]
        public void SetUp() {
            ServiceLocatorInitializer.Init();
            controller = new GroupsController(CreateMockVirtualGroupRepository());
        }

        /// <summary>
        /// Add a couple of objects to the list within CreateVirtualGroups and change the 
        /// "ShouldEqual(0)" within this test to the respective number.
        /// </summary>
        [Test]
        public void CanListVirtualGroups() {
            ViewResult result = controller.Index().AssertViewRendered();

            result.ViewData.Model.ShouldNotBeNull();
            (result.ViewData.Model as List<Group>).Count.ShouldEqual(0);
        }

        [Test]
        public void CanShowVirtualGroup() {
            ViewResult result = controller.Show(1).AssertViewRendered();

			result.ViewData.ShouldNotBeNull();
			
            (result.ViewData.Model as Group).Id.ShouldEqual(1);
        }

        [Test]
        public void CanInitVirtualGroupCreation() {
            ViewResult result = controller.Create().AssertViewRendered();
            
            result.ViewData.Model.ShouldNotBeNull();
            result.ViewData.Model.ShouldBeOfType(typeof(GroupFormViewModel));
            (result.ViewData.Model as GroupFormViewModel).Group.ShouldBeNull();
        }

        [Test]
        public void CanEnsureVirtualGroupCreationIsValid() {
            Group virtualGroupFromForm = new Group();
            ViewResult result = controller.Create(virtualGroupFromForm).AssertViewRendered();

            result.ViewData.Model.ShouldNotBeNull();
            result.ViewData.Model.ShouldBeOfType(typeof(GroupFormViewModel));
        }

        [Test]
        public void CanCreateVirtualGroup() {
            Group virtualGroupFromForm = CreateTransientVirtualGroup();
            RedirectToRouteResult redirectResult = controller.Create(virtualGroupFromForm)
                .AssertActionRedirect().ToAction("Index");
            controller.TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()].ToString()
				.ShouldContain("was successfully created");
        }

        [Test]
        public void CanUpdateVirtualGroup() {
            Group virtualGroupFromForm = CreateTransientVirtualGroup();
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
            result.ViewData.Model.ShouldBeOfType(typeof(GroupFormViewModel));
            (result.ViewData.Model as GroupFormViewModel).Group.Id.ShouldEqual(1);
        }

        [Test]
        public void CanDeleteVirtualGroup() {
            RedirectToRouteResult redirectResult = controller.Delete(1)
                .AssertActionRedirect().ToAction("Index");
            
            controller.TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()].ToString()
				.ShouldContain("was successfully deleted");
        }

		#region Create Mock VirtualGroup Repository

        private IGroupManagementService CreateMockVirtualGroupRepository()
        {

            IGroupManagementService mockedRepository = MockRepository.GenerateMock<IGroupManagementService>();
            mockedRepository.Expect(mr => mr.GetAll()).Return(CreateVirtualGroups());
            mockedRepository.Expect(mr => mr.Get(1)).IgnoreArguments().Return(CreateVirtualGroup());

			IDbContext mockedDbContext = MockRepository.GenerateStub<IDbContext>();
			mockedDbContext.Stub(c => c.CommitChanges());
			
            
            return mockedRepository;
        }

        private IRepository<User> CreateMockUserRepository()
        {

            IRepository<User> mockedRepository = MockRepository.GenerateMock<IRepository<User>>();
            mockedRepository.Expect(mr => mr.GetAll()).Return(CreateUsers());
            mockedRepository.Expect(mr => mr.Get(1)).IgnoreArguments().Return(CreateUser());
            mockedRepository.Expect(mr => mr.SaveOrUpdate(null)).IgnoreArguments().Return(CreateUser());
            mockedRepository.Expect(mr => mr.Delete(null)).IgnoreArguments();

            IDbContext mockedDbContext = MockRepository.GenerateStub<IDbContext>();
            mockedDbContext.Stub(c => c.CommitChanges());
            mockedRepository.Stub(mr => mr.DbContext).Return(mockedDbContext);

            return mockedRepository;
        }

        private Group CreateVirtualGroup() {
            Group virtualGroup = CreateTransientVirtualGroup();
            EntityIdSetter.SetIdOf<int>(virtualGroup, 1);
            return virtualGroup;
        }

        private User CreateUser()
        {
            User user = CreateTransientUser();
            EntityIdSetter.SetIdOf<int>(user, 1);
            return user;
        }

        private List<Group> CreateVirtualGroups() {
            List<Group> virtualGroups = new List<Group>();

            // Create a number of domain object instances here and add them to the list

            return virtualGroups;
        }

        private List<User> CreateUsers()
        {
            List<User> user = new List<User>();

            // Create a number of domain object instances here and add them to the list

            return user;
        }

        #endregion

        /// <summary>
        /// Creates a valid, transient VirtualGroup; typical of something retrieved back from a form submission
        /// </summary>
        private Group CreateTransientVirtualGroup() {
            Group virtualGroup = new Group() {
				Name = "VAN",
				Blog = "http://wwww.virtualaltnet.com",
				Manager = null
            };
            
            return virtualGroup;
        }

        private User CreateTransientUser()
        {
            User user = new User()
            {
                UserName = "VAN",

            };

            return user;
        }

        private GroupsController controller;
    }
}
