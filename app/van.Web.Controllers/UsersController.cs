using System.Web.Mvc;
using van.ApplicationServices;
using van.ApplicationServices.ManagementService;
using van.ApplicationServices.ViewModels;
using van.Core;
using SharpArch.Core.PersistenceSupport;
using System.Collections.Generic;
using SharpArch.Web.NHibernate;
using SharpArch.Core;
using van.Web.Controllers.Infrastructure;
using van.Web.Core;

namespace van.Web.Controllers
{
    [HandleError]
    public class UsersController : Controller
    {
        public UsersController(IUserManagementService userManagementService)
        {
            Check.Require(userManagementService != null, "userRepository may not be null");

            this.userManagementService = userManagementService;
        }

        [RequiresAuthentication]
        [RequiresAuthorization(RoleToCheckFor = "Administrator")]
        [Transaction]
        [ResourceFilter(1)]
        public ActionResult Index() {
            UserFormViewModel model = userManagementService.GetUsers();       
            return View(model);
        }

        [RequiresAuthentication]
        [RequiresAuthorization(RoleToCheckFor = "Administrator")]
        [Transaction]
        [ResourceFilter(1)]
        public ActionResult Show(int id) {
            UserFormViewModel model = userManagementService.CreateFormViewModelFor(id);   
            return View(model);
        }

        [RequiresAuthentication]
        [RequiresAuthorization(RoleToCheckFor = "Administrator")]
        [ResourceFilter(1)]
        public ActionResult Create() {
            UserFormViewModel viewModel = userManagementService.CreateFormViewModel();
            return View(viewModel);
        }

        [RequiresAuthentication]
        [RequiresAuthorization(RoleToCheckFor = "Administrator")]
        [ValidateAntiForgeryToken]
        [Transaction]
        [AcceptVerbs(HttpVerbs.Post)]
        [ResourceFilter(1)]
        public ActionResult Create(User user) {
            if (ViewData.ModelState.IsValid) {
                ActionConfirmation saveOrUpdateConfirmation = userManagementService.SaveOrUpdate(user);

                if (saveOrUpdateConfirmation.WasSuccessful)
                {
                    TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()] = saveOrUpdateConfirmation.Message;
                    return RedirectToAction("Index");
                }
            }

            UserFormViewModel viewModel = userManagementService.CreateFormViewModelFor(user);            
            return View(viewModel);
        }

        [RequiresAuthentication]
        [RequiresAuthorization(RoleToCheckFor = "Administrator")]
        [Transaction]
        [ResourceFilter(1)]
        public ActionResult Edit(int id) {
            UserFormViewModel viewModel = userManagementService.CreateFormViewModelFor(id);
            
            return View(viewModel);
        }

        [RequiresAuthentication]
        [RequiresAuthorization(RoleToCheckFor = "Administrator")]
        [ValidateAntiForgeryToken]
        [Transaction]
        [AcceptVerbs(HttpVerbs.Post)]
        [ResourceFilter(1)]
        public ActionResult Edit(User user) {
            if (ViewData.ModelState.IsValid)
            {
                ActionConfirmation updateConfirmation = userManagementService.UpdateWith(user);

                if (updateConfirmation.WasSuccessful)
                {
                    TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()] = updateConfirmation.Message;
                    return RedirectToAction("Index");
                }
            }

            UserFormViewModel viewModel = userManagementService.CreateFormViewModelFor(user);
            return View(viewModel);
        }

        [RequiresAuthentication]
        [RequiresAuthorization(RoleToCheckFor = "Administrator")]
        [ValidateAntiForgeryToken]
        [Transaction]
        [AcceptVerbs(HttpVerbs.Post)]
        [ResourceFilter(1)]
        public ActionResult Delete(int id) {
            ActionConfirmation deleteConfirmation = userManagementService.Delete(id);
            TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()] = deleteConfirmation.Message;
            return RedirectToAction("Index");

        }

        private readonly IUserManagementService userManagementService;
    }
}
