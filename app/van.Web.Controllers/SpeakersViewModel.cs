using System.Collections.Generic;
using van.Core;

namespace van.Web.Controllers
{
    public class SpeakersViewModel : BaseViewModel
	{
        public Speaker SingleSpeaker { get; set; }

        public IList<Speaker> Speakers { get; set; }
	}
}