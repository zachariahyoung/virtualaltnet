using System.Configuration;

namespace van.Web.Core.Configuration
{
	public class ContentFileSection : ConfigurationSection
	{
		/// <summary>
		/// Gets the CSS files.
		/// </summary>
		/// <value>The CSS files.</value>
		[ConfigurationProperty("css", IsDefaultCollection = false, IsRequired = false)]
		public ContentFileCollection CSSFiles
		{
			get { return (ContentFileCollection)base["css"]; }
		}

		/// <summary>
		/// Gets the java script files.
		/// </summary>
		/// <value>The java script files.</value>
		[ConfigurationProperty("javascript", IsDefaultCollection = true, IsRequired = false)]
		public ContentFileCollection JavaScriptFiles
		{
			get { return (ContentFileCollection)base["javascript"]; }
		}

		/// <summary>
		/// Gets the java script files.
		/// </summary>
		/// <value>The java script files.</value>
		[ConfigurationProperty("resource", IsDefaultCollection = true, IsRequired = false)]
		public ResourceConfigurationCollection Resource
		{
			get { return (ResourceConfigurationCollection)base["resource"]; }
		}

		/// <summary>
		/// Gets or sets the XML namespace.
		/// </summary>
		/// <value>The XML namespace.</value>
		[ConfigurationProperty("xmlns", DefaultValue = "")]
		public string XmlNamespace
		{
			get
			{
				return (string)base["xmlns"];
			}
			set
			{
				base["xmlns"] = value;
			}
		}
	}
}