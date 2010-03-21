using System.Collections.Generic;
using van.ApplicationServices.ViewModels;
using van.Core;

namespace van.ApplicationServices.ManagementService
{
    public interface IUserManagementService{
        User Get(int id);
        IList<User> GetAll();
        UserFormViewModel CreateFormViewModel();
        UserFormViewModel CreateFormViewModelFor(int userId);
        UserFormViewModel CreateFormViewModelFor(User product);
        UserFormViewModel GetUsers();
        ActionConfirmation SaveOrUpdate(User product);
        ActionConfirmation UpdateWith(User userFromForm);
        ActionConfirmation Delete(int id);
    }
}