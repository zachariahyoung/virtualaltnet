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
using van.Web.Controllers.Infrastructure;
using van.Web.Core;

namespace van.Web.Controllers
{
    [HandleError]
    public class GroupsController : Controller
    {
        public GroupsController(IRepository<Group> groupRepository) {
            Check.Require(groupRepository != null, "groupRepository may not be null");

            this.groupRepository = groupRepository;
        }

        [RequiresAuthentication]
        [RequiresAuthorization(RoleToCheckFor = "Administrator")]
        [Transaction]
        [ResourceFilter(1)]
        public ActionResult Index() {

            var model = new GroupsViewModel()
            {
                Groups = groupRepository.GetAll()
            };

            return View(model);
        }

        [RequiresAuthentication]
        [RequiresAuthorization(RoleToCheckFor = "Administrator")]
        [Transaction]
        [ResourceFilter(1)]
        public ActionResult Show(int id) {

            var model = new GroupsViewModel()
            {
                SingleGroup = groupRepository.Get(id)
            };
            return View(model);
        }

        [RequiresAuthentication]
        [RequiresAuthorization(RoleToCheckFor = "Administrator")]
        [ResourceFilter(1)]
        public ActionResult Create() {
            GroupFormViewModel viewModel = GroupFormViewModel.CreateGroupFormViewModel();
            return View(viewModel);
        }

        [RequiresAuthentication]
        [RequiresAuthorization(RoleToCheckFor = "Administrator")]
        [ValidateAntiForgeryToken]
        [Transaction]
        [AcceptVerbs(HttpVerbs.Post)]
        [ResourceFilter(1)]
        public ActionResult Create(Group group)
        {
            if (ViewData.ModelState.IsValid && group.IsValid()) {
                groupRepository.SaveOrUpdate(group);

                TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()] = 
					"The group was successfully created.";
                return RedirectToAction("Index");
            }

            GroupFormViewModel viewModel = GroupFormViewModel.CreateGroupFormViewModel();
            viewModel.group = group;
            return View(viewModel);
        }

        [RequiresAuthentication]
        [RequiresAuthorization(RoleToCheckFor = "Administrator")]
        [Transaction]
        [ResourceFilter(1)]
        public ActionResult Edit(int id) {
            GroupFormViewModel viewModel = GroupFormViewModel.CreateGroupFormViewModel();
            viewModel.group = groupRepository.Get(id);
            return View(viewModel);
        }

        [RequiresAuthentication]
        [RequiresAuthorization(RoleToCheckFor = "Administrator")]
        [ValidateAntiForgeryToken]
        [Transaction]
        [AcceptVerbs(HttpVerbs.Post)]
        [ResourceFilter(1)]
        public ActionResult Edit(Group group)
        {
            Group groupToUpdate = groupRepository.Get(group.Id);
            TransferFormValuesTo(groupToUpdate, group);

            if (ViewData.ModelState.IsValid && group.IsValid()) {
                TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()] = 
					"The group was successfully updated.";
                return RedirectToAction("Index");
            }
            else {
                groupRepository.DbContext.RollbackTransaction();

				GroupFormViewModel viewModel = GroupFormViewModel.CreateGroupFormViewModel();
				viewModel.group = group;
				return View(viewModel);
            }
        }

        private void TransferFormValuesTo(Group groupToUpdate, Group groupFromForm) {
			groupToUpdate.Name = groupFromForm.Name;
            groupToUpdate.ShortName = groupFromForm.ShortName;
			groupToUpdate.Website = groupFromForm.Website;
			groupToUpdate.Manager = groupFromForm.Manager;
        }

        [RequiresAuthentication]
        [RequiresAuthorization(RoleToCheckFor = "Administrator")]
        [ValidateAntiForgeryToken]
        [Transaction]
        [AcceptVerbs(HttpVerbs.Post)]
        [ResourceFilter(1)]
        public ActionResult Delete(int id)
        {
            string resultMessage = "The Group was successfully deleted.";
            Group groupToDelete = groupRepository.Get(id);

            if (groupToDelete != null) {
                groupRepository.Delete(groupToDelete);

                try {
                    groupRepository.DbContext.CommitChanges();
                }
                catch {
                    resultMessage = "A problem was encountered preventing the Group from being deleted. " +
						"Another item likely depends on this Group.";
                    groupRepository.DbContext.RollbackTransaction();
                }
            }
            else {
                resultMessage = "The Group could not be found for deletion. It may already have been deleted.";
            }

            TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()] = resultMessage;
            return RedirectToAction("Index");
        }

		/// <summary>
		/// Holds data to be passed to the group form for creates and edits
		/// </summary>
        public class GroupFormViewModel : BaseViewModel
        {
            private GroupFormViewModel() { }

			/// <summary>
			/// Creation method for creating the view model. Services may be passed to the creation 
			/// method to instantiate items such as lists for drop down boxes.
			/// </summary>
            public static GroupFormViewModel CreateGroupFormViewModel() {
                GroupFormViewModel viewModel = new GroupFormViewModel();
                
                return viewModel;
            }

            public Group group { get; internal set; }
        }

        private readonly IRepository<Group> groupRepository;
    }
}
