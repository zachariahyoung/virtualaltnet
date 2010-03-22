using System.Web.Mvc;
using van.ApplicationServices.ManagementService;
using van.ApplicationServices.ViewModels;
using van.Core;
using SharpArch.Core.PersistenceSupport;
using SharpArch.Web.NHibernate;
using SharpArch.Core;
using van.Web.Controllers.Infrastructure;
using van.Web.Core;

namespace van.Web.Controllers
{
    [HandleErrorAttribute]

    public class RecordingsController : Controller
    {
        public RecordingsController(IRecordingManagementService recordingManagementService)
        {
            Check.Require(recordingManagementService != null, "recordingManagementService may not be null");

            this.recordingManagementService = recordingManagementService;
        }

        [Transaction]
        [ResourceFilter(2)]
        public ActionResult Index() {
            RecordingFormViewModel model = recordingManagementService.GetRecordings();
            return View(model);

        }

        [Transaction]
        [ResourceFilter(1)]
        public ActionResult Show(int id) {
            RecordingFormViewModel model = recordingManagementService.CreateFormViewModelFor(id);
            return View(model);
        }

        [RequiresAuthentication]
        [RequiresAuthorization(RoleToCheckFor = "Administrator")]
        [ResourceFilter(1)]
        public ActionResult Create() {
            RecordingFormViewModel viewModel = recordingManagementService.CreateFormViewModel();
            return View(viewModel);
        }

        [RequiresAuthentication]
        [RequiresAuthorization(RoleToCheckFor = "Administrator")]
        [ValidateAntiForgeryToken]
        [Transaction]
        [AcceptVerbs(HttpVerbs.Post)]
        [ResourceFilter(1)]
        public ActionResult Create(Recording recording) {
            if (ViewData.ModelState.IsValid)
            {
                ActionConfirmation saveOrUpdateConfirmation = recordingManagementService.SaveOrUpdate(recording);

                if (saveOrUpdateConfirmation.WasSuccessful)
                {
                    TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()] = saveOrUpdateConfirmation.Message;
                    return RedirectToAction("Index");
                }
            }

            RecordingFormViewModel viewModel = recordingManagementService.CreateFormViewModelFor(recording);
            return View(viewModel);

        }

        [RequiresAuthentication]
        [RequiresAuthorization(RoleToCheckFor = "Administrator")]
        [Transaction]
        [ResourceFilter(1)]
        public ActionResult Edit(int id) {
            RecordingFormViewModel viewModel = recordingManagementService.CreateFormViewModelFor(id);
            return View(viewModel);
        }

        [RequiresAuthentication]
        [RequiresAuthorization(RoleToCheckFor = "Administrator")]
        [ValidateAntiForgeryToken]
        [Transaction]
        [AcceptVerbs(HttpVerbs.Post)]
        [ResourceFilter(1)]
        public ActionResult Edit(Recording recording) {
            if (ViewData.ModelState.IsValid)
            {
                ActionConfirmation updateConfirmation = recordingManagementService.UpdateWith(recording);

                if (updateConfirmation.WasSuccessful)
                {
                    TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()] = updateConfirmation.Message;
                    return RedirectToAction("Index");
                }
            }

            RecordingFormViewModel viewModel = recordingManagementService.CreateFormViewModelFor(recording);
            return View(viewModel);

        }

        [RequiresAuthentication]
        [RequiresAuthorization(RoleToCheckFor = "Administrator")]
        [ValidateAntiForgeryToken]
        [Transaction]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete(int id) {
            ActionConfirmation deleteConfirmation = recordingManagementService.Delete(id);
            TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()] = deleteConfirmation.Message;
            return RedirectToAction("Index");
        }

        private readonly IRecordingManagementService recordingManagementService;
    }
}
