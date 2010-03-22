using System.Web.Mvc;
using van.ApplicationServices;
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
    public class GroupsController : Controller
    {
        public GroupsController(IGroupManagementService groupManagementService) {
            Check.Require(groupManagementService != null, "groupManagementService may not be null");

            this.groupManagementService = groupManagementService;
            
        }

        [RequiresAuthentication]
        [RequiresAuthorization(RoleToCheckFor = "Administrator")]
        [Transaction]
        [ResourceFilter(1)]
        public ActionResult Index()
        {
            GroupFormViewModel model = groupManagementService.GetGroups();
            return View(model);
        }

        [RequiresAuthentication]
        [RequiresAuthorization(RoleToCheckFor = "Administrator")]
        [Transaction]
        [ResourceFilter(1)]
        public ActionResult Show(int id)
        {
            GroupFormViewModel model = groupManagementService.CreateFormViewModelFor(id);
            return View(model);
        }

        [RequiresAuthentication]
        [RequiresAuthorization(RoleToCheckFor = "Administrator")]
        [ResourceFilter(1)]
        public ActionResult Create() {
            GroupFormViewModel viewModel = groupManagementService.CreateFormViewModel();
            return View(viewModel);
        }

        [RequiresAuthentication]
        [RequiresAuthorization(RoleToCheckFor = "Administrator")]
        [ValidateAntiForgeryToken]
        [Transaction]
        [AcceptVerbs(HttpVerbs.Post)]
        [ResourceFilter(1)]
        public ActionResult Create(Group group) {
            if (ViewData.ModelState.IsValid)
            {
                ActionConfirmation saveOrUpdateConfirmation = groupManagementService.SaveOrUpdate(group);

                if (saveOrUpdateConfirmation.WasSuccessful)
                {
                    TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()] = saveOrUpdateConfirmation.Message;
                    return RedirectToAction("Index");
                }
            }

            GroupFormViewModel viewModel = groupManagementService.CreateFormViewModelFor(group);
            return View(viewModel);
        }

        [RequiresAuthentication]
        [RequiresAuthorization(RoleToCheckFor = "Administrator")]
        [Transaction]
        [ResourceFilter(1)]
        public ActionResult Edit(int id) {
            GroupFormViewModel viewModel = groupManagementService.CreateFormViewModelFor(id);
            return View(viewModel);
        }

        [RequiresAuthentication]
        [RequiresAuthorization(RoleToCheckFor = "Administrator")]
        [ValidateAntiForgeryToken]
        [Transaction]
        [AcceptVerbs(HttpVerbs.Post)]
        [ResourceFilter(1)]
        public ActionResult Edit(Group group) {
            if (ViewData.ModelState.IsValid)
            {
                ActionConfirmation updateConfirmation = groupManagementService.UpdateWith(group);

                if (updateConfirmation.WasSuccessful)
                {
                    TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()] = updateConfirmation.Message;
                    return RedirectToAction("Index");
                }
            }

            GroupFormViewModel viewModel = groupManagementService.CreateFormViewModelFor(group);
            return View(viewModel);
        }

        [RequiresAuthentication]
        [RequiresAuthorization(RoleToCheckFor = "Administrator")]
        [ValidateAntiForgeryToken]
        [Transaction]
        [AcceptVerbs(HttpVerbs.Post)]
        [ResourceFilter(1)]
        public ActionResult Delete(int id) {
            ActionConfirmation deleteConfirmation = groupManagementService.Delete(id);
            TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()] = deleteConfirmation.Message;
            return RedirectToAction("Index");
        }

        private readonly IGroupManagementService groupManagementService;        
        
    }
}
