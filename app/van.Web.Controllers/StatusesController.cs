using System.Web.Mvc;
using van.ApplicationServices.ManagementService;
using van.ApplicationServices.ViewModels;
using van.Core;
using SharpArch.Core.PersistenceSupport;
using SharpArch.Core.DomainModel;
using System.Collections.Generic;
using System;
using SharpArch.Web.NHibernate;
using NHibernate.Validator.Engine;
using System.Text;
using SharpArch.Web.CommonValidator;
using SharpArch.Core;
using van.Web.Controllers.Infrastructure;
using van.Web.Core;

namespace van.Web.Controllers
{
    [HandleError]
    public class StatusesController : Controller
    {
        public StatusesController(IStatusManagementService statusManagementService) {
            Check.Require(statusManagementService != null, "statusRepository may not be null");

            this.statusManagementService = statusManagementService;
        }
        
        [RequiresAuthentication]
        [RequiresAuthorization(RoleToCheckFor = "Administrator")]
        [Transaction]
        [ResourceFilter(1)]
        public ActionResult Index() {
            StatusFormViewModel model = statusManagementService.GetStatuss();
            return View(model);

        }

        [RequiresAuthentication]
        [RequiresAuthorization(RoleToCheckFor = "Administrator")]
        [Transaction]
        [ResourceFilter(1)]
        public ActionResult Show(int id) {
            StatusFormViewModel model = statusManagementService.CreateFormViewModelFor(id);
            return View(model);
        }
        
        [RequiresAuthentication]
        [RequiresAuthorization(RoleToCheckFor = "Administrator")]
        [ResourceFilter(1)]
        public ActionResult Create() {
            StatusFormViewModel viewModel = statusManagementService.CreateFormViewModel();
            return View(viewModel);
        }

        [RequiresAuthentication]
        [RequiresAuthorization(RoleToCheckFor = "Administrator")]
        [ResourceFilter(1)]
        [ValidateAntiForgeryToken]
        [Transaction]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(Status status) {
            if (ViewData.ModelState.IsValid)
            {
                ActionConfirmation saveOrUpdateConfirmation = statusManagementService.SaveOrUpdate(status);

                if (saveOrUpdateConfirmation.WasSuccessful)
                {
                    TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()] = saveOrUpdateConfirmation.Message;
                    return RedirectToAction("Index");
                }
            }

            StatusFormViewModel viewModel = statusManagementService.CreateFormViewModelFor(status);
            return View(viewModel);

        }

        [RequiresAuthentication]
        [RequiresAuthorization(RoleToCheckFor = "Administrator")]
        [ResourceFilter(1)]
        [Transaction]
        public ActionResult Edit(int id) {
            StatusFormViewModel viewModel = statusManagementService.CreateFormViewModelFor(id);

            return View(viewModel);

        }

        [RequiresAuthentication]
        [RequiresAuthorization(RoleToCheckFor = "Administrator")]
        [ResourceFilter(1)]
        [ValidateAntiForgeryToken]
        [Transaction]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(Status status) {
            if (ViewData.ModelState.IsValid)
            {
                ActionConfirmation updateConfirmation = statusManagementService.UpdateWith(status);

                if (updateConfirmation.WasSuccessful)
                {
                    TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()] = updateConfirmation.Message;
                    return RedirectToAction("Index");
                }
            }

            StatusFormViewModel viewModel = statusManagementService.CreateFormViewModelFor(status);
            return View(viewModel);

        }

        [RequiresAuthentication]
        [RequiresAuthorization(RoleToCheckFor = "Administrator")]
        [ResourceFilter(1)]
        [ValidateAntiForgeryToken]
        [Transaction]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete(int id) {
            ActionConfirmation deleteConfirmation = statusManagementService.Delete(id);
            TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()] = deleteConfirmation.Message;
            return RedirectToAction("Index");

        }
        
        private readonly IStatusManagementService statusManagementService;
    }
}
