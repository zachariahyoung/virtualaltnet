using System.Collections.Generic;
using SharpArch.Core;
using van.ApplicationServices.ViewModels;
using van.Core;
using van.Core.DataInterfaces;

namespace van.ApplicationServices.ManagementService
{
    public class GroupManagementService : IGroupManagementService{

        public GroupManagementService(IGroupRepository groupRepository, IUserManagementService userManagementService)
        {
            Check.Require(groupRepository != null, "groupRepository may not be null");
            this.groupRepository = groupRepository;
            this.userManagementService = userManagementService;
        }

        public Group Get(int id)
        {            
            return groupRepository.Get(id);            
        }

        public IList<Group> GetAll()
        {
            return groupRepository.GetAll();
        }

        public GroupFormViewModel CreateFormViewModel()
        {
            GroupFormViewModel model = new GroupFormViewModel();
            model.Users = userManagementService.GetAll();
            return model;
        }

        public GroupFormViewModel CreateFormViewModelFor(Group group)
        {
            GroupFormViewModel viewModel = CreateFormViewModel();
            viewModel.Group = group;
            return viewModel;
        }

        public GroupFormViewModel CreateFormViewModelFor(int groupId)
        {
            Group group = groupRepository.Get(groupId);
            return CreateFormViewModelFor(group);
        }

        public GroupFormViewModel GetGroups()
        {
            GroupFormViewModel viewModel = new GroupFormViewModel();
            viewModel.Groups = groupRepository.GetAll();
            return viewModel;
        }

        public ActionConfirmation SaveOrUpdate(Group group)
        {
            if (group.IsValid())
            {
                groupRepository.SaveOrUpdate(group);

                ActionConfirmation saveOrUpdateConfirmation = ActionConfirmation.CreateSuccessConfirmation(
                    "The group was successfully saved.");
                saveOrUpdateConfirmation.Value = group;

                return saveOrUpdateConfirmation;
            }
            else
            {
                groupRepository.DbContext.RollbackTransaction();

                return ActionConfirmation.CreateFailureConfirmation(
                    "The group could not be saved due to missing or invalid information.");
            }

            
        }

        public ActionConfirmation UpdateWith(Group groupFromForm)
        {
            Group groupToUpdate = groupRepository.Get(groupFromForm.Id);
            TransferFormValuesTo(groupToUpdate, groupFromForm);

            if (groupToUpdate.IsValid())
            {
                ActionConfirmation updateConfirmation = ActionConfirmation.CreateSuccessConfirmation(
                    "The group was successfully updated.");
                updateConfirmation.Value = groupToUpdate;

                return updateConfirmation;
            }
            else
            {
                groupRepository.DbContext.RollbackTransaction();

                return ActionConfirmation.CreateFailureConfirmation(
                    "The group could not be saved due to missing or invalid information.");
            }
        }

        public ActionConfirmation Delete(int id)
        {
            Group groupToDelete = groupRepository.Get(id);

            if (groupToDelete != null)
            {
                groupRepository.Delete(groupToDelete);

                try
                {
                    groupRepository.DbContext.CommitChanges();

                    return ActionConfirmation.CreateSuccessConfirmation(
                        "The group was successfully deleted.");
                }
                catch
                {
                    groupRepository.DbContext.RollbackTransaction();

                    return ActionConfirmation.CreateFailureConfirmation(
                        "A problem was encountered preventing the group from being deleted. " +
                        "Another item likely depends on this group.");
                }
            }
            else
            {
                return ActionConfirmation.CreateFailureConfirmation(
                    "The group could not be found for deletion. It may already have been deleted.");
            }
        }

        private void TransferFormValuesTo(Group groupToUpdate, Group groupFromForm)
        {
            groupToUpdate.Name = groupFromForm.Name;
            groupToUpdate.ShortName = groupFromForm.ShortName;
            groupToUpdate.Blog = groupFromForm.Blog;
            groupToUpdate.Rss = groupFromForm.Rss;
            groupToUpdate.Manager = groupFromForm.Manager;
        }

        IGroupRepository groupRepository;
        IUserManagementService userManagementService;
       
    }
}