using System.Web.Mvc;
using van.Core;
using SharpArch.Core.PersistenceSupport;
using System.Collections.Generic;
using SharpArch.Web.NHibernate;
using SharpArch.Core;
using van.Web.Controllers.Infrastructure;

namespace van.Web.Controllers
{
    [HandleError]
    public class UsersController : Controller
    {
        public UsersController(IRepository<User> userRepository) {
            Check.Require(userRepository != null, "userRepository may not be null");

            this.userRepository = userRepository;
        }
        [RequiresAuthentication]
        [RequiresAuthorization(RoleToCheckFor = "Administrator")]
        [Transaction]
        public ActionResult Index() {
            IList<User> users = userRepository.GetAll();
            return View(users);
        }
        [RequiresAuthentication]
        [RequiresAuthorization(RoleToCheckFor = "Administrator")]
        [Transaction]
        public ActionResult Show(int id) {
            User user = userRepository.Get(id);
            return View(user);
        }

        [RequiresAuthentication]
        [RequiresAuthorization(RoleToCheckFor = "Administrator")]
        public ActionResult Create() {
            UserFormViewModel viewModel = UserFormViewModel.CreateUserFormViewModel();
            return View(viewModel);
        }

        [RequiresAuthentication]
        [RequiresAuthorization(RoleToCheckFor = "Administrator")]
        [ValidateAntiForgeryToken]
        [Transaction]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(User user) {
            if (ViewData.ModelState.IsValid && user.IsValid()) {
                userRepository.SaveOrUpdate(user);

                TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()] = 
					"The user was successfully created.";
                return RedirectToAction("Index");
            }

            UserFormViewModel viewModel = UserFormViewModel.CreateUserFormViewModel();
            viewModel.User = user;
            return View(viewModel);
        }

        [RequiresAuthentication]
        [RequiresAuthorization(RoleToCheckFor = "Administrator")]
        [Transaction]
        public ActionResult Edit(int id) {
            UserFormViewModel viewModel = UserFormViewModel.CreateUserFormViewModel();
            viewModel.User = userRepository.Get(id);
            return View(viewModel);
        }

        [RequiresAuthentication]
        [RequiresAuthorization(RoleToCheckFor = "Administrator")]
        [ValidateAntiForgeryToken]
        [Transaction]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(User user) {
            User userToUpdate = userRepository.Get(user.Id);
            TransferFormValuesTo(userToUpdate, user);

            if (ViewData.ModelState.IsValid && user.IsValid()) {
                TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()] = 
					"The user was successfully updated.";
                return RedirectToAction("Index");
            }
            userRepository.DbContext.RollbackTransaction();

            UserFormViewModel viewModel = UserFormViewModel.CreateUserFormViewModel();
            viewModel.User = user;
            return View(viewModel);
        }

        private static void TransferFormValuesTo(User userToUpdate, User userFromForm) {
			userToUpdate.UserName = userFromForm.UserName;
			userToUpdate.Password = userFromForm.Password;
        }

        [RequiresAuthentication]
        [RequiresAuthorization(RoleToCheckFor = "Administrator")]
        [ValidateAntiForgeryToken]
        [Transaction]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete(int id) {
            string resultMessage = "The user was successfully deleted.";
            User userToDelete = userRepository.Get(id);

            if (userToDelete != null) {
                userRepository.Delete(userToDelete);

                try {
                    userRepository.DbContext.CommitChanges();
                }
                catch {
                    resultMessage = "A problem was encountered preventing the user from being deleted. " +
						"Another item likely depends on this user.";
                    userRepository.DbContext.RollbackTransaction();
                }
            }
            else {
                resultMessage = "The user could not be found for deletion. It may already have been deleted.";
            }

            TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()] = resultMessage;
            return RedirectToAction("Index");
        }

		/// <summary>
		/// Holds data to be passed to the User form for creates and edits
		/// </summary>
        public class UserFormViewModel
        {
            private UserFormViewModel() { }

			/// <summary>
			/// Creation method for creating the view model. Services may be passed to the creation 
			/// method to instantiate items such as lists for drop down boxes.
			/// </summary>
            public static UserFormViewModel CreateUserFormViewModel() {
                var viewModel = new UserFormViewModel();
                
                return viewModel;
            }

            public User User { get; internal set; }
        }

        private readonly IRepository<User> userRepository;
    }
}