using System.Configuration;

namespace van.Web.Core.Configuration
{
	/// <summary>
	/// Content files like css and javascript. Properties come from the Browser object so the person
	/// configuring the app can base it on browser.
	/// </summary>
	public class ContentFile : ConfigurationElement
	{
		/// <summary>
		/// Gets the path.
		/// </summary>
		/// <value>The path.</value>
		[ConfigurationProperty("path", IsRequired = true)]
		public string Path
		{
			get { return (string)base["path"]; }
		}

		[ConfigurationProperty("id", IsRequired = true)]
		public int Id
		{
			get
			{
				return (int)base["id"];
			}
		}
	}
}