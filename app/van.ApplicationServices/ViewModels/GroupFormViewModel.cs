using System.Collections.Generic;
using van.Core;

namespace van.ApplicationServices.ViewModels
{
    public class GroupFormViewModel : BaseViewModel
    {
        public Group Group { get; set; }

        public IList<Group> Groups { get; set; }

        public IEnumerable<User> Users { get; set; }

    }
}