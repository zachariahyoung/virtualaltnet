using System.Collections.Generic;
using van.Core;

namespace van.Web.Controllers
{
	public class UsersViewModel : BaseViewModel
	{
        public User SingleUser{ get; set; }

		public IList<User> Users{ get; set; }
	}
}