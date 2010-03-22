using System.Collections.Generic;
using van.ApplicationServices.ViewModels;
using van.Core;

namespace van.ApplicationServices.ManagementService
{
    public interface ISpeakerManagementService {
        Speaker Get(int id);
        IList<Speaker> GetAll();
        SpeakerFormViewModel CreateFormViewModel();
        SpeakerFormViewModel CreateFormViewModelFor(int speakerId);
        SpeakerFormViewModel CreateFormViewModelFor(Speaker speaker);
        SpeakerFormViewModel GetSpeakers();
        ActionConfirmation SaveOrUpdate(Speaker speaker);
        ActionConfirmation UpdateWith(Speaker speakerFromForm);
        ActionConfirmation Delete(int id);
        
    }
}