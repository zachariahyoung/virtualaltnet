using System;
using System.Collections.Generic;
using System.Configuration;
using van.Core;
using van.Web.Core.Configuration;

namespace van.Web.Core
{
	/// <summary>
	/// The content files manager is the get request repository for the css and javascript files. It was made into a 
	/// factory class so that it can be stubbed out in required tests.
	/// </summary>
	public class ContentFilesManager : IContentFilesManager
	{
		readonly IAppSettings _appSettings;
		private ContentFileSection _contentSection;

		/// <summary>
		/// Initializes a new instance of the <see cref="ContentFilesManager"/> class.
		/// </summary>
		/// <param name="appSettings">The app settings.</param>
		public ContentFilesManager(IAppSettings appSettings)
		{
			_appSettings = appSettings;
		}

		/// <summary>
		/// Gets or sets the content section out of the configuration file which are ConfigurationElements.
		/// </summary>
		/// <value>The content section.</value>
		public virtual ContentFileSection ContentSection
		{
			get
			{
				if (_contentSection == null)
					_contentSection = ConfigurationManager.GetSection(_appSettings.ContentFiles) as ContentFileSection;

				return _contentSection;
			}
			set { _contentSection = value; }
		}

		/// <summary>
		/// Get either the css or javascript files. Content will be filter based on the browser requesting the content if the browser attributes
		/// are set within the configuration file.
		/// </summary>
		/// <param name="filesType">Type of the files.</param>
		/// <param name="id">The id.</param>
		/// <returns></returns>
		public ICollection<IResource> GetFiles(ContentFilesType filesType, int id)
		{
			if (ContentSection == null)
				return null;

			var ienum = ContentSection.Resource.GetEnumerator(); // [id];
			var allconfigurations = new List<ResourceConfiguration>();

			while(ienum.MoveNext())
			{
				allconfigurations.Add((ResourceConfiguration)ienum.Current);
			}

			var resourceConfiguration = allconfigurations.Find(c => c.Id == id);
			IEnumerable<int> ids = null;

			switch (filesType)
			{
				case ContentFilesType.CSS:
					if (resourceConfiguration != null) ids = resourceConfiguration.CSSIds;
					return FilterContent(ContentSection.CSSFiles, ids);

				case ContentFilesType.JavaScript:
					if (resourceConfiguration != null) ids = resourceConfiguration.JavaScriptIds;
					return FilterContent(ContentSection.JavaScriptFiles, ids);
			}

			return null;
		}

		/// <summary>
		/// Filters the content based on the browser requesting the content. If the browser attribute is set then the other browser attributes must be set
		/// in order to work for that particular item. If they are not set then the file is added to the collection. If the browser attributes are set then
		/// the requesting browser must match or be in between the major and minor versions set in the configuration file.
		/// </summary>
		/// <param name="contentFileCollection">The content file collection.</param>
		/// <param name="ids">The ids.</param>
		/// <returns></returns>
		private static ICollection<IResource> FilterContent(ContentFileCollection contentFileCollection, IEnumerable<int> ids)
		{
			var files = new List<IResource>();

			if (contentFileCollection == null) return files;
			if (ids == null) return files;
			
			var newIds = new List<int>(ids);

			foreach (ContentFile contentFile in contentFileCollection)
			{
				if (!newIds.Contains(contentFile.Id)) continue;
				
				if (!String.IsNullOrEmpty(contentFile.Path))
					files.Add(new WebResource(contentFile.Path));
			}

			return files;
		}
	}
}