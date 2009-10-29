using System.Collections.Generic;

namespace van.Core
{
	public class BaseViewModel
	{
		/// <summary>
		/// Gets or sets the CSS includes.
		/// </summary>
		/// <value>The CSS includes.</value>
		public ICollection<IResource> CSS { get; set; }

		/// <summary>
		/// Gets or sets the java script includes.
		/// </summary>
		/// <value>The java script includes.</value>
		public ICollection<IResource> JavaScript { get; set; }
	}
}