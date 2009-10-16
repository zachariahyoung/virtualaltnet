using System.Collections.Generic;
using van.Core;
using van.Web.Core.Configuration;

namespace van.Web.Core
{
	public interface IContentFilesManager
	{
		/// <summary>
		/// Gets or sets the content section.
		/// </summary>
		/// <value>The content section.</value>
		ContentFileSection ContentSection { get; set; }

		/// <summary>
		/// Gets the files.
		/// </summary>
		/// <param name="filesType">Type of the files.</param>
		/// <param name="id">The id.</param>
		/// <returns></returns>
		ICollection<IResource> GetFiles(ContentFilesType filesType, int id);
	}
}