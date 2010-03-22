using System.Collections.Generic;
using van.Core;

namespace van.ApplicationServices.ViewModels
{
    public class SpeakerFormViewModel : BaseViewModel
    {
        public Speaker Speaker { get; set; }

        public IList<Speaker> Speakers { get; set; }
       
    }
}