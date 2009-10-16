using System;
using System.Collections.Generic;
using System.Configuration;

namespace van.Web.Core.Configuration
{
	public class ResourceConfiguration : ConfigurationElement
	{
		/// <summary>
		/// Gets the id.
		/// </summary>
		/// <value>The id.</value>
		[ConfigurationProperty("id", IsRequired = true)]
		public int Id
		{
			get
			{
				return (int)base["id"];
			}
		}

		/// <summary>
		/// Gets the JavaScript ids.
		/// </summary>
		/// <value>The JavaScript ids.</value>
		[ConfigurationProperty("jIds", IsRequired = true)]
		private string jIds
		{
			get
			{
				var tmp = (string) base["jIds"];
				return String.IsNullOrEmpty(tmp) ? String.Empty : tmp;
			}
		}

		/// <summary>
		/// Gets the java script ids.
		/// </summary>
		/// <value>The java script ids.</value>
		public IEnumerable<int> JavaScriptIds
		{
			get
			{
				var ids = jIds.Split(",".ToCharArray());

				foreach (var id in ids)
				{
					yield return int.Parse(id);
				}
			}
		}

		/// <summary>
		/// Gets the CSS ids.
		/// </summary>
		/// <value>The CSS ids.</value>
		[ConfigurationProperty("cssIds", IsRequired = true)]
		public string cssIds
		{
			get
			{
				var tmp = (string) base["cssIds"];
				return String.IsNullOrEmpty(tmp) ? String.Empty : tmp;
			}
		}

		/// <summary>
		/// Gets the CSS ids.
		/// </summary>
		/// <value>The CSS ids.</value>
		public IEnumerable<int> CSSIds
		{
			get
			{
				var ids = cssIds.Split(",".ToCharArray());

				foreach (var id in ids)
				{
					yield return int.Parse(id);
				}
			}
		}

		/// <summary>
		/// Gets the name.
		/// </summary>
		/// <value>The name.</value>
		[ConfigurationProperty("name", IsRequired = false)]
		public string Name
		{
			get { return (string)base["name"]; }
		}
	}
}