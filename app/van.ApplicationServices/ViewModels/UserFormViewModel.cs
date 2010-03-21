using System.Collections.Generic;
using van.Core;

namespace van.ApplicationServices.ViewModels
{
    public class UserFormViewModel : BaseViewModel
    {
        public User User { get; set; }

        public IList<User> Users { get; set; }
    }
}