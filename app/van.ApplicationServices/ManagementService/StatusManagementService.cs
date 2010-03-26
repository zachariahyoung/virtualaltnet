using System;
using System.Collections.Generic;
using SharpArch.Core;
using van.ApplicationServices.ViewModels;
using van.Core;
using van.Core.DataInterfaces;

namespace van.ApplicationServices.ManagementService
{
    public class StatusManagementService : IStatusManagementService {
        
        public StatusManagementService(IStatusRepository statusRepository) {
            Check.Require(statusRepository != null, "userRepository may not be null");
            this.statusRepository = statusRepository;            
        }

        public Status Get(int id) {
            return statusRepository.Get(id);            
        }

        public IList<Status> GetAll() {
            return statusRepository.GetAll();
        }

        public StatusFormViewModel CreateFormViewModel() {
            StatusFormViewModel model = new StatusFormViewModel();
            return model;
        }

        public StatusFormViewModel CreateFormViewModelFor(int statusId) {
            Status user = statusRepository.Get(statusId);
            return CreateFormViewModelFor(user);
        }

        public StatusFormViewModel CreateFormViewModelFor(Status status) {
            StatusFormViewModel viewModel = CreateFormViewModel();
            viewModel.Status = status;
            return viewModel;

        }

        public StatusFormViewModel GetStatuss() {
            StatusFormViewModel viewModel = new StatusFormViewModel();
            viewModel.Statuses = statusRepository.GetAll();
            return viewModel;

        }

        public ActionConfirmation SaveOrUpdate(Status status) {
            if (status.IsValid())
            {
                statusRepository.SaveOrUpdate(status);

                ActionConfirmation saveOrUpdateConfirmation = ActionConfirmation.CreateSuccessConfirmation(
                    "The status was successfully saved.");
                saveOrUpdateConfirmation.Value = status;

                return saveOrUpdateConfirmation;
            }
            else
            {
                statusRepository.DbContext.RollbackTransaction();

                return ActionConfirmation.CreateFailureConfirmation(
                    "The status could not be saved due to missing or invalid information.");
            }
        }

        public ActionConfirmation UpdateWith(Status statusFromForm) {
            Status statusToUpdate = statusRepository.Get(statusFromForm.Id);
            TransferFormValuesTo(statusToUpdate, statusFromForm);

            if (statusToUpdate.IsValid())
            {
                ActionConfirmation updateConfirmation = ActionConfirmation.CreateSuccessConfirmation(
                    "The user was successfully updated.");
                updateConfirmation.Value = statusToUpdate;

                return updateConfirmation;
            }
            else
            {
                statusRepository.DbContext.RollbackTransaction();

                return ActionConfirmation.CreateFailureConfirmation(
                    "The user could not be saved due to missing or invalid information.");
            }

        }
        
        public ActionConfirmation Delete(int id) {
            Status statusToDelete = statusRepository.Get(id);

            if (statusToDelete != null)
            {
                statusRepository.Delete(statusToDelete);

                try
                {
                    statusRepository.DbContext.CommitChanges();

                    return ActionConfirmation.CreateSuccessConfirmation(
                        "The status was successfully deleted.");
                }
                catch
                {
                    statusRepository.DbContext.RollbackTransaction();

                    return ActionConfirmation.CreateFailureConfirmation(
                        "A problem was encountered preventing the status from being deleted. " +
                        "Another item likely depends on this status.");
                }
            }
            else
            {
                return ActionConfirmation.CreateFailureConfirmation(
                    "The status could not be found for deletion. It may already have been deleted.");
            }

        }

        private void TransferFormValuesTo(Status statusToUpdate, Status statusFromForm)
        {
            statusToUpdate.Name = statusFromForm.Name;
        }

        IStatusRepository statusRepository;
    }
}