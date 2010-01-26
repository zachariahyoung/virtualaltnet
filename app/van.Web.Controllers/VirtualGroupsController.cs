using System.Web.Mvc;
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

namespace van.Web.Controllers
{
    [HandleError]
    public class VirtualGroupsController : Controller
    {
        public VirtualGroupsController(IRepository<VirtualGroup> virtualGroupRepository) {
            Check.Require(virtualGroupRepository != null, "virtualGroupRepository may not be null");

            this.virtualGroupRepository = virtualGroupRepository;
        }

        [Transaction]
        public ActionResult Index() {
            IList<VirtualGroup> virtualGroups = virtualGroupRepository.GetAll();
            return View(virtualGroups);
        }

        [Transaction]
        public ActionResult Show(int id) {
            VirtualGroup virtualGroup = virtualGroupRepository.Get(id);
            return View(virtualGroup);
        }

        public ActionResult Create() {
            VirtualGroupFormViewModel viewModel = VirtualGroupFormViewModel.CreateVirtualGroupFormViewModel();
            return View(viewModel);
        }

        [ValidateAntiForgeryToken]
        [Transaction]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(VirtualGroup virtualGroup) {
            if (ViewData.ModelState.IsValid && virtualGroup.IsValid()) {
                virtualGroupRepository.SaveOrUpdate(virtualGroup);

                TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()] = 
					"The virtualGroup was successfully created.";
                return RedirectToAction("Index");
            }

            VirtualGroupFormViewModel viewModel = VirtualGroupFormViewModel.CreateVirtualGroupFormViewModel();
            viewModel.VirtualGroup = virtualGroup;
            return View(viewModel);
        }

        [Transaction]
        public ActionResult Edit(int id) {
            VirtualGroupFormViewModel viewModel = VirtualGroupFormViewModel.CreateVirtualGroupFormViewModel();
            viewModel.VirtualGroup = virtualGroupRepository.Get(id);
            return View(viewModel);
        }

        [ValidateAntiForgeryToken]
        [Transaction]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(VirtualGroup virtualGroup) {
            VirtualGroup virtualGroupToUpdate = virtualGroupRepository.Get(virtualGroup.Id);
            TransferFormValuesTo(virtualGroupToUpdate, virtualGroup);

            if (ViewData.ModelState.IsValid && virtualGroup.IsValid()) {
                TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()] = 
					"The virtualGroup was successfully updated.";
                return RedirectToAction("Index");
            }
            else {
                virtualGroupRepository.DbContext.RollbackTransaction();

				VirtualGroupFormViewModel viewModel = VirtualGroupFormViewModel.CreateVirtualGroupFormViewModel();
				viewModel.VirtualGroup = virtualGroup;
				return View(viewModel);
            }
        }

        private void TransferFormValuesTo(VirtualGroup virtualGroupToUpdate, VirtualGroup virtualGroupFromForm) {
			virtualGroupToUpdate.GroupName = virtualGroupFromForm.GroupName;
			virtualGroupToUpdate.Website = virtualGroupFromForm.Website;
			virtualGroupToUpdate.Manager = virtualGroupFromForm.Manager;
        }

        [ValidateAntiForgeryToken]
        [Transaction]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete(int id) {
            string resultMessage = "The virtualGroup was successfully deleted.";
            VirtualGroup virtualGroupToDelete = virtualGroupRepository.Get(id);

            if (virtualGroupToDelete != null) {
                virtualGroupRepository.Delete(virtualGroupToDelete);

                try {
                    virtualGroupRepository.DbContext.CommitChanges();
                }
                catch {
                    resultMessage = "A problem was encountered preventing the virtualGroup from being deleted. " +
						"Another item likely depends on this virtualGroup.";
                    virtualGroupRepository.DbContext.RollbackTransaction();
                }
            }
            else {
                resultMessage = "The virtualGroup could not be found for deletion. It may already have been deleted.";
            }

            TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()] = resultMessage;
            return RedirectToAction("Index");
        }

		/// <summary>
		/// Holds data to be passed to the VirtualGroup form for creates and edits
		/// </summary>
        public class VirtualGroupFormViewModel
        {
            private VirtualGroupFormViewModel() { }

			/// <summary>
			/// Creation method for creating the view model. Services may be passed to the creation 
			/// method to instantiate items such as lists for drop down boxes.
			/// </summary>
            public static VirtualGroupFormViewModel CreateVirtualGroupFormViewModel() {
                VirtualGroupFormViewModel viewModel = new VirtualGroupFormViewModel();
                
                return viewModel;
            }

            public VirtualGroup VirtualGroup { get; internal set; }
        }

        private readonly IRepository<VirtualGroup> virtualGroupRepository;
    }
}