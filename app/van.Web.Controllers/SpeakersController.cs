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
    public class SpeakersController : Controller
    {
        public SpeakersController(ISpeakerManagementService speakerManagementService) {
            Check.Require(speakerManagementService != null, "speakerManagementService may not be null");

            this.speakerManagementService = speakerManagementService;
        }

        [RequiresAuthentication]
        [RequiresAuthorization(RoleToCheckFor = "Administrator")]
        [Transaction]
        [ResourceFilter(1)]
        public ActionResult Index() {
            SpeakerFormViewModel model = speakerManagementService.GetSpeakers();
            return View(model);
        }

        [Transaction]
        [ResourceFilter(1)]
        public ActionResult Show(int id) {
            SpeakerFormViewModel model = speakerManagementService.CreateFormViewModelFor(id);
            return View(model);
        }

        [RequiresAuthentication]
        [RequiresAuthorization(RoleToCheckFor = "Administrator")]
        [ResourceFilter(1)]
        public ActionResult Create() {
            SpeakerFormViewModel viewModel = speakerManagementService.CreateFormViewModel();
            return View(viewModel);
        }

        [RequiresAuthentication]
        [RequiresAuthorization(RoleToCheckFor = "Administrator")]
        [ValidateAntiForgeryToken]
        [Transaction]
        [AcceptVerbs(HttpVerbs.Post)]
        [ResourceFilter(1)]
        public ActionResult Create(Speaker speaker) {
            if (ViewData.ModelState.IsValid)
            {
                ActionConfirmation saveOrUpdateConfirmation = speakerManagementService.SaveOrUpdate(speaker);

                if (saveOrUpdateConfirmation.WasSuccessful)
                {
                    TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()] = saveOrUpdateConfirmation.Message;
                    return RedirectToAction("Index");
                }
            }

            SpeakerFormViewModel viewModel = speakerManagementService.CreateFormViewModelFor(speaker);
            return View(viewModel);
        }

        [RequiresAuthentication]
        [RequiresAuthorization(RoleToCheckFor = "Administrator")]
        [Transaction]
        [ResourceFilter(1)]
        public ActionResult Edit(int id) {
            SpeakerFormViewModel viewModel = speakerManagementService.CreateFormViewModelFor(id);

            return View(viewModel);
        }

        [RequiresAuthentication]
        [RequiresAuthorization(RoleToCheckFor = "Administrator")]
        [ValidateAntiForgeryToken]
        [Transaction]
        [AcceptVerbs(HttpVerbs.Post)]
        [ResourceFilter(1)]
        public ActionResult Edit(Speaker speaker) {
            if (ViewData.ModelState.IsValid)
            {
                ActionConfirmation updateConfirmation = speakerManagementService.UpdateWith(speaker);

                if (updateConfirmation.WasSuccessful)
                {
                    TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()] = updateConfirmation.Message;
                    return RedirectToAction("Index");
                }
            }

            SpeakerFormViewModel viewModel = speakerManagementService.CreateFormViewModelFor(speaker);
            return View(viewModel);
        }

        [RequiresAuthentication]
        [RequiresAuthorization(RoleToCheckFor = "Administrator")]
        [ValidateAntiForgeryToken]
        [Transaction]
        [AcceptVerbs(HttpVerbs.Post)]
        [ResourceFilter(1)]
        public ActionResult Delete(int id) {
            ActionConfirmation deleteConfirmation = speakerManagementService.Delete(id);
            TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()] = deleteConfirmation.Message;
            return RedirectToAction("Index");
        }

        private readonly ISpeakerManagementService speakerManagementService;
    }
}
