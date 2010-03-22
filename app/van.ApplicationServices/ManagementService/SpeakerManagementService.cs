using System;
using System.Collections.Generic;
using SharpArch.Core;
using van.ApplicationServices.ViewModels;
using van.Core;
using van.Core.DataInterfaces;

namespace van.ApplicationServices.ManagementService
{
    public class SpeakerManagementService : ISpeakerManagementService {

        public SpeakerManagementService(ISpeakerRepository speakerRepository)
        {
            Check.Require(speakerRepository != null, "speakerRepository may not be null");
            this.speakerRepository = speakerRepository;

        }
        
        public Speaker Get(int id) {
            return speakerRepository.Get(id);            
        }

        public IList<Speaker> GetAll() {
            return speakerRepository.GetAll();
        }

        public SpeakerFormViewModel CreateFormViewModel() {
            SpeakerFormViewModel model = new SpeakerFormViewModel();
            return model;
        }

        public SpeakerFormViewModel CreateFormViewModelFor(Speaker speaker) {
            SpeakerFormViewModel viewModel = CreateFormViewModel();
            viewModel.Speaker = speaker;
            return viewModel;
        }

        public SpeakerFormViewModel CreateFormViewModelFor(int speakerId) {
            Speaker speaker = speakerRepository.Get(speakerId);
            return CreateFormViewModelFor(speaker);
        }       

        public SpeakerFormViewModel GetSpeakers() {
            SpeakerFormViewModel viewModel = new SpeakerFormViewModel();
            viewModel.Speakers = speakerRepository.GetAll();
            return viewModel;

        }

        public ActionConfirmation SaveOrUpdate(Speaker speaker) {
            if (speaker.IsValid())
            {
                speakerRepository.SaveOrUpdate(speaker);

                ActionConfirmation saveOrUpdateConfirmation = ActionConfirmation.CreateSuccessConfirmation(
                    "The user was successfully saved.");
                saveOrUpdateConfirmation.Value = speaker;

                return saveOrUpdateConfirmation;
            }
            else
            {
                speakerRepository.DbContext.RollbackTransaction();

                return ActionConfirmation.CreateFailureConfirmation(
                    "The user could not be saved due to missing or invalid information.");
            }

        }

        public ActionConfirmation UpdateWith(Speaker speakerFromForm) {
            Speaker speakerToUpdate = speakerRepository.Get(speakerFromForm.Id);
            TransferFormValuesTo(speakerToUpdate, speakerFromForm);

            if (speakerToUpdate.IsValid())
            {
                ActionConfirmation updateConfirmation = ActionConfirmation.CreateSuccessConfirmation(
                    "The speaker was successfully updated.");
                updateConfirmation.Value = speakerToUpdate;

                return updateConfirmation;
            }
            else
            {
                speakerRepository.DbContext.RollbackTransaction();

                return ActionConfirmation.CreateFailureConfirmation(
                    "The speaker could not be saved due to missing or invalid information.");
            }

        }

        public ActionConfirmation Delete(int id)
        {
            Speaker speakerToDelete = speakerRepository.Get(id);

            if (speakerToDelete != null)
            {
                speakerRepository.Delete(speakerToDelete);

                try
                {
                    speakerRepository.DbContext.CommitChanges();

                    return ActionConfirmation.CreateSuccessConfirmation(
                        "The speaker was successfully deleted.");
                }
                catch
                {
                    speakerRepository.DbContext.RollbackTransaction();

                    return ActionConfirmation.CreateFailureConfirmation(
                        "A problem was encountered preventing the speaker from being deleted. " +
                        "Another item likely depends on this user.");
                }
            }
            else
            {
                return ActionConfirmation.CreateFailureConfirmation(
                    "The speaker could not be found for deletion. It may already have been deleted.");
            }
        }

        private void TransferFormValuesTo(Speaker speakerToUpdate, Speaker speakerFromForm)
        {
            speakerToUpdate.Name = speakerFromForm.Name;
            speakerToUpdate.Email = speakerFromForm.Email;
            speakerToUpdate.Website = speakerFromForm.Website;
            speakerToUpdate.Bio = speakerFromForm.Bio;

        }

        ISpeakerRepository speakerRepository;
    }
}