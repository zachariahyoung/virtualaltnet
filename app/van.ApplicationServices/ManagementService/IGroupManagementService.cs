using System.Collections.Generic;
using van.ApplicationServices.ViewModels;
using van.Core;

namespace van.ApplicationServices.ManagementService
{
    public interface IGroupManagementService{
        Group Get(int id);
        IList<Group> GetAll();
        GroupFormViewModel CreateFormViewModel();
        GroupFormViewModel CreateFormViewModelFor(int groupId);
        GroupFormViewModel CreateFormViewModelFor(Group group);
        GroupFormViewModel GetGroups();
        ActionConfirmation SaveOrUpdate(Group group);
        ActionConfirmation UpdateWith(Group groupFromForm);
        ActionConfirmation Delete(int id);        
    }
}