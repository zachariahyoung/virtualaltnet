using System.Collections.Generic;
using van.ApplicationServices.ViewModels;
using van.Core;

namespace van.ApplicationServices.ManagementService
{
    public interface IStatusManagementService {
        Status Get(int id);
        IList<Status> GetAll();
        StatusFormViewModel CreateFormViewModel();
        StatusFormViewModel CreateFormViewModelFor(int statusId);
        StatusFormViewModel CreateFormViewModelFor(Status status);
        StatusFormViewModel GetStatuss();
        ActionConfirmation SaveOrUpdate(Status status);
        ActionConfirmation UpdateWith(Status statusFromForm);
        ActionConfirmation Delete(int id);        
        
    }
}