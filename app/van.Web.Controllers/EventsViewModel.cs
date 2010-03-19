using System.Collections.Generic;
using van.Core;

namespace van.Web.Controllers
{
    public class EventsViewModel : BaseViewModel
	{
        public Event SingleEvent { get; set; }

        public IList<Event> Events { get; set; }
	}
}