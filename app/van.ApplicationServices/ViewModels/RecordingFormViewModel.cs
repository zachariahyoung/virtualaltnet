using System.Collections.Generic;
using van.Core;
using van.Core.Dto;

namespace van.ApplicationServices.ViewModels
{
    public class RecordingFormViewModel : BaseViewModel
    {
        public Recording Recording { get; set; }

        public IList<RecordingDto> Recordings { get; set; }

        public IList<Speaker> Speakers { get; set; }

        public IList<Group> Groups { get; set; }

    }
}