using System;
using System.Collections.Generic;
using SharpArch.Core;
using van.ApplicationServices.ViewModels;
using van.Core;
using van.Core.DataInterfaces;

namespace van.ApplicationServices.ManagementService
{
    public class RecordingManagementService : IRecordingManagementService {

        public RecordingManagementService(IRecordingRepository recordingRepository, IGroupManagementService groupManagementService, ISpeakerManagementService speakerManagementService) {
            Check.Require(recordingRepository != null, "recordingRepository may not be null");
            Check.Require(groupManagementService != null, "groupManagementService may not be null");
            Check.Require(speakerManagementService != null, "speakerManagementService may not be null");

            this.recordingRepository = recordingRepository;
            this.groupManagementService = groupManagementService;
            this.speakerManagementService = speakerManagementService;
            
        }

        public Recording Get(int id) {
            return recordingRepository.Get(id);            
        }

        public IList<Recording> GetAll() {
            return recordingRepository.GetAll();
        }

        public RecordingFormViewModel CreateFormViewModel() {
            RecordingFormViewModel model = new RecordingFormViewModel();
            model.Groups = groupManagementService.GetAll();
            model.Speakers = speakerManagementService.GetAll();
            return model;

        }

        public RecordingFormViewModel CreateFormViewModelFor(Recording recording) {
            RecordingFormViewModel viewModel = CreateFormViewModel();
            viewModel.Recording = recording;
            return viewModel;

        }

        public RecordingFormViewModel CreateFormViewModelFor(int recordingId) {
            Recording recording = recordingRepository.Get(recordingId);
            return CreateFormViewModelFor(recording);

        }

        public RecordingFormViewModel GetRecordings() {
            RecordingFormViewModel viewModel = new RecordingFormViewModel();
            viewModel.Recordings = recordingRepository.GetRecordingSummaries();
            return viewModel;

        }

        public ActionConfirmation SaveOrUpdate(Recording recording) {
            if (recording.IsValid())
            {
                recordingRepository.SaveOrUpdate(recording);

                ActionConfirmation saveOrUpdateConfirmation = ActionConfirmation.CreateSuccessConfirmation(
                    "The recording was successfully saved.");
                saveOrUpdateConfirmation.Value = recording;

                return saveOrUpdateConfirmation;
            }
            else
            {
                recordingRepository.DbContext.RollbackTransaction();

                return ActionConfirmation.CreateFailureConfirmation(
                    "The recording could not be saved due to missing or invalid information.");
            }            

        }

        public ActionConfirmation UpdateWith(Recording recordingFromForm) {
            Recording recordingToUpdate = recordingRepository.Get(recordingFromForm.Id);
            TransferFormValuesTo(recordingToUpdate, recordingFromForm);

            if (recordingToUpdate.IsValid())
            {
                ActionConfirmation updateConfirmation = ActionConfirmation.CreateSuccessConfirmation(
                    "The recording was successfully updated.");
                updateConfirmation.Value = recordingToUpdate;

                return updateConfirmation;
            }
            else
            {
                recordingRepository.DbContext.RollbackTransaction();

                return ActionConfirmation.CreateFailureConfirmation(
                    "The group could not be saved due to missing or invalid information.");
            }

        }

        public ActionConfirmation Delete(int id) {
            Recording recordingToDelete = recordingRepository.Get(id);

            if (recordingToDelete != null)
            {
                recordingRepository.Delete(recordingToDelete);

                try
                {
                    recordingRepository.DbContext.CommitChanges();

                    return ActionConfirmation.CreateSuccessConfirmation(
                        "The recording was successfully deleted.");
                }
                catch
                {
                    recordingRepository.DbContext.RollbackTransaction();

                    return ActionConfirmation.CreateFailureConfirmation(
                        "A problem was encountered preventing the recording from being deleted. " +
                        "Another item likely depends on this recording.");
                }
            }
            else
            {
                return ActionConfirmation.CreateFailureConfirmation(
                    "The recording could not be found for deletion. It may already have been deleted.");
            }
        }

        private void TransferFormValuesTo(Recording recordingToUpdate, Recording recordingFromForm)                 
        {
            recordingToUpdate.Title = recordingFromForm.Title;
            recordingToUpdate.Url = recordingFromForm.Url;
            recordingToUpdate.Date = recordingFromForm.Date;
            recordingToUpdate.Duration = recordingFromForm.Duration;
            recordingToUpdate.Speaker = recordingFromForm.Speaker;
            recordingToUpdate.Group = recordingFromForm.Group;
            recordingToUpdate.LiveMeetingUrl = recordingFromForm.LiveMeetingUrl;
            recordingToUpdate.Description = recordingFromForm.Description;
        }

        IRecordingRepository recordingRepository;
        IGroupManagementService groupManagementService;
        ISpeakerManagementService speakerManagementService;
    }
}