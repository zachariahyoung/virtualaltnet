using System.Collections.Generic;
using van.ApplicationServices.ViewModels;
using van.Core;

namespace van.ApplicationServices.ManagementService
{
    public interface IRecordingManagementService {
        Recording Get(int id);
        IList<Recording> GetAll();
        RecordingFormViewModel CreateFormViewModel();
        RecordingFormViewModel CreateFormViewModelFor(int recordingId);
        RecordingFormViewModel CreateFormViewModelFor(Recording recording);
        RecordingFormViewModel GetRecordings();
        RecordingFormViewModel GetEvents();
        ActionConfirmation SaveOrUpdate(Recording recording);
        ActionConfirmation UpdateWith(Recording recordingFromForm);
        ActionConfirmation Delete(int id);

    }
}