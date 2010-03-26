using System;
using System.Collections.Generic;
using SharpArch.Core;
using van.ApplicationServices.ViewModels;
using van.Core;
using van.Core.DataInterfaces;

namespace van.ApplicationServices.ManagementService
{
    public class UserManagementService : IUserManagementService {
        
        public UserManagementService(IUserRepository userRepository){
            Check.Require(userRepository != null, "userRepository may not be null");
            this.userRepository = userRepository;
        }

        public User Get(int id) {            
            return userRepository.Get(id);            
        } 

        public IList<User> GetAll() {
            return userRepository.GetAll();
        }
        
        public UserFormViewModel CreateFormViewModel() {
            UserFormViewModel model = new UserFormViewModel();
            return model;
        }

        public UserFormViewModel CreateFormViewModelFor(User user){
            UserFormViewModel viewModel = CreateFormViewModel();
            viewModel.User = user;
            return viewModel;
        }

        public UserFormViewModel CreateFormViewModelFor(int userId){
            User user = userRepository.Get(userId);
            return CreateFormViewModelFor(user);
        }

        public UserFormViewModel GetUsers(){
            UserFormViewModel viewModel = new UserFormViewModel();
            viewModel.Users = userRepository.GetAll();
            return viewModel;
        }
    
        public ActionConfirmation SaveOrUpdate(User user) {
            if (user.IsValid())
            {
                userRepository.SaveOrUpdate(user);

                ActionConfirmation saveOrUpdateConfirmation = ActionConfirmation.CreateSuccessConfirmation(
                    "The user was successfully saved.");
                saveOrUpdateConfirmation.Value = user;

                return saveOrUpdateConfirmation;
            }
            else
            {
                userRepository.DbContext.RollbackTransaction();

                return ActionConfirmation.CreateFailureConfirmation(
                    "The user could not be saved due to missing or invalid information.");
            }
            
        }

        public ActionConfirmation UpdateWith(User userFromForm) {
            User userToUpdate = userRepository.Get(userFromForm.Id);
            TransferFormValuesTo(userToUpdate, userFromForm);

            if (userToUpdate.IsValid())
            {
                ActionConfirmation updateConfirmation = ActionConfirmation.CreateSuccessConfirmation(
                    "The user was successfully updated.");
                updateConfirmation.Value = userToUpdate;

                return updateConfirmation;
            }
            else
            {
                userRepository.DbContext.RollbackTransaction();

                return ActionConfirmation.CreateFailureConfirmation(
                    "The user could not be saved due to missing or invalid information.");
            }
        }

        public ActionConfirmation Delete(int id) {
            User userToDelete = userRepository.Get(id);

            if (userToDelete != null)
            {
                userRepository.Delete(userToDelete);

                try
                {
                    userRepository.DbContext.CommitChanges();

                    return ActionConfirmation.CreateSuccessConfirmation(
                        "The user was successfully deleted.");
                }
                catch
                {
                    userRepository.DbContext.RollbackTransaction();

                    return ActionConfirmation.CreateFailureConfirmation(
                        "A problem was encountered preventing the user from being deleted. " +
                        "Another item likely depends on this user.");
                }
            }
            else
            {
                return ActionConfirmation.CreateFailureConfirmation(
                    "The user could not be found for deletion. It may already have been deleted.");
            }
        }

        private void TransferFormValuesTo(User userToUpdate, User userFromForm)
        {
            userToUpdate.UserName = userFromForm.UserName;
            userToUpdate.Password = userFromForm.Password;
        }

        IUserRepository userRepository;
    }
}