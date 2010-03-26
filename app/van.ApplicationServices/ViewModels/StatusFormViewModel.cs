using System.Collections.Generic;
using van.Core;

namespace van.ApplicationServices.ViewModels
{
    public class StatusFormViewModel : BaseViewModel
    {
        public Status Status { get; set; }

        public IList<Status> Statuses { get; set; }

    }
}