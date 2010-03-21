using MvcContrib.TestHelper;
using NUnit.Framework;
using Rhino.Mocks;
using SharpArch.Core.PersistenceSupport;
using SharpArch.Testing;
using SharpArch.Testing.NUnit;
using System.Collections.Generic;
using System.Web.Mvc;
using van.ApplicationServices;
using van.ApplicationServices.ViewModels;
using van.Core;
using van.Web.Controllers;
 

namespace Tests.van.Web.Controllers
{
    [TestFixture]
    public class UsersControllerTests
    {
        [SetUp]
        public void SetUp() {
            ServiceLocatorInitializer.Init();
            controller = new UsersController(CreateMockUserRepository());
        }

        /// <summary>
        /// Add a couple of objects to the list within CreateUsers and change the 
        /// "ShouldEqual(0)" within this test to the respective number.
        /// </summary>
        [Test]
        public void CanListUsers() {
            ViewResult result = controller.Index().AssertViewRendered();
            result.ViewData.Model.ShouldNotBeNull();
            (result.ViewData.Model as List<User>).Count.ShouldEqual(2);
        }

        [Test]
        public void CanShowUser() {
            ViewResult result = controller.Show(1).AssertViewRendered();

			result.ViewData.ShouldNotBeNull();
			
            (result.ViewData.Model as User).Id.ShouldEqual(1);
        }

        [Test]
        public void CanInitUserCreation() {
            ViewResult result = controller.Create().AssertViewRendered();
            
            result.ViewData.Model.ShouldNotBeNull();
            result.ViewData.Model.ShouldBeOfType(typeof(UserFormViewModel));
            (result.ViewData.Model as UserFormViewModel).User.ShouldBeNull();
        }

      //  [Test]
        ///TODO: MAKE THIS PASS IN FUTURE REVS
      //  public void CanEnsureUserCreationIsValid() {
            
      //      var userFromForm = new User();
      //      Assert.IsTrue(userFromForm.IsValid());

      //      ViewResult result = controller.Create(userFromForm).AssertViewRendered();

      //      //ViewResult viewRendered = controller.Create(userFromForm).AssertViewRendered();
      //     // Assert.IsTrue(viewRendered.ViewData.ModelState.IsValid);
      ////      ActionResult result = controller.Create(userFromForm).AssertActionRedirect();
        
      //      //RedirectResult result = controller.Create(userFromForm).AssertHttpRedirect();
      //      //result.ToUrl("/User/Create");
      //      result.ViewData.Model.ShouldNotBeNull();
      //      result.ViewData.Model.ShouldBeOfType(typeof(UsersController.UserFormViewModel));
      //  }

        [Test]
        public void CanCreateUser() {
            User userFromForm = CreateTransientUser();
            RedirectToRouteResult redirectResult = controller.Create(userFromForm)
                .AssertActionRedirect().ToAction("Index");
            controller.TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()].ToString()
				.ShouldContain("was successfully created");
        }

        [Test]
        public void CanUpdateUser() {
            User userFromForm = CreateTransientUser();
            EntityIdSetter.SetIdOf<int>(userFromForm, 1);
            RedirectToRouteResult redirectResult = controller.Edit(userFromForm)
                .AssertActionRedirect().ToAction("Index");
            controller.TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()].ToString()
				.ShouldContain("was successfully updated");
        }

        [Test]
        public void CanInitUserEdit() {
            ViewResult result = controller.Edit(1).AssertViewRendered();

			result.ViewData.Model.ShouldNotBeNull();
            result.ViewData.Model.ShouldBeOfType(typeof(UserFormViewModel));
            (result.ViewData.Model as UserFormViewModel).User.Id.ShouldEqual(1);
        }

        [Test]
        public void CanDeleteUser() {
            RedirectToRouteResult redirectResult = controller.Delete(1)
                .AssertActionRedirect().ToAction("Index");
            
            controller.TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()].ToString()
				.ShouldContain("was successfully deleted");
        }

		#region Create Mock User Repository

        private IUserManagementService CreateMockUserRepository()
        {

            var mockedRepository = MockRepository.GenerateMock<IUserManagementService>();
            mockedRepository.Expect(mr => mr.GetAll()).Return(CreateUsers());
            mockedRepository.Expect(mr => mr.Get(1)).IgnoreArguments().Return(CreateUser());
            

			IDbContext mockedDbContext = MockRepository.GenerateStub<IDbContext>();
			mockedDbContext.Stub(c => c.CommitChanges());
			
            
            return mockedRepository;
        }

        private UserFormViewModel CreateUser()
        {
            User user = CreateTransientUser();
            EntityIdSetter.SetIdOf<int>(user, 1);
            UserFormViewModel model = new UserFormViewModel();
            model.User = user;
            return model;
        }

        private UserFormViewModel CreateUsers()
        {
            var users = new List<User>();
            var user = new User {UserName = "JohnL", Password = "123456"};
            var user1 = new User { UserName = "JohnLeg", Password = "1234567" };
            users.Add(user);
            users.Add(user1);
            UserFormViewModel model = new UserFormViewModel();
            model.Users = users;

            // Create a number of domain object instances here and add them to the list
            return model;
        }
        
        #endregion

        /// <summary>
        /// Creates a valid, transient User; typical of something retrieved back from a form submission
        /// </summary>
        private User CreateTransientUser() {
            User user = new User() {
				UserName = "JoeLouis",
				Password = "******"
            };
            
            return user;
        }

        private UsersController controller;
    }
}
