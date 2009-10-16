using System.Configuration;

namespace van.Web.Core.Configuration
{
	public class ContentFileCollection : ConfigurationElementCollection
	{
		/// <summary>
		/// When overridden in a derived class, creates a new <see cref="T:System.Configuration.ConfigurationElement"/>.
		/// </summary>
		/// <returns>
		/// A new <see cref="T:System.Configuration.ConfigurationElement"/>.
		/// </returns>
		protected override ConfigurationElement CreateNewElement()
		{
			return new ContentFile();
		}

		/// <summary>
		/// Gets the element key for a specified configuration element when overridden in a derived class.
		/// </summary>
		/// <param name="element">The <see cref="T:System.Configuration.ConfigurationElement"/> to return the key for.</param>
		/// <returns>
		/// An <see cref="T:System.Object"/> that acts as the key for the specified <see cref="T:System.Configuration.ConfigurationElement"/>.
		/// </returns>
		protected override object GetElementKey(ConfigurationElement element)
		{
			return ((ContentFile)element).Id;
		}

		/// <summary>
		/// Gets the <see cref="ContentFile"/> with the specified key.
		/// </summary>
		/// <value></value>
		new public ContentFile this[string key]
		{
			get { return (ContentFile)BaseGet(key); }
		}

		/// <summary>
		/// Gets or sets the <see cref="ContentFile"/> at the specified index.
		/// </summary>
		/// <value></value>
		public ContentFile this[int index]
		{
			get { return (ContentFile)BaseGet(index); }
			set
			{
				if (BaseGet(index) != null)
					BaseRemoveAt(index);

				BaseAdd(index, value);
			}
		}
	}
}