using System.Collections.Generic;
using van.Core;

namespace van.Web.Controllers
{
    public class GroupsViewModel : BaseViewModel
	{
        public Group SingleGroup { get; set; }

        public IList<Group> Groups { get; set; }
	}
}