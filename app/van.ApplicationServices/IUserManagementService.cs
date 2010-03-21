using System.Collections.Generic;
using van.ApplicationServices.ViewModels;
using van.Core;

namespace van.ApplicationServices
{
    public interface IUserManagementService
    {
        UserFormViewModel CreateFormViewModel();
        UserFormViewModel CreateFormViewModelFor(int userId);
        UserFormViewModel CreateFormViewModelFor(User product);
        UserFormViewModel Get(int id);
        UserFormViewModel GetAll();
        ActionConfirmation SaveOrUpdate(User product);
        ActionConfirmation UpdateWith(User userFromForm);
        ActionConfirmation Delete(int id);
        
    }
}