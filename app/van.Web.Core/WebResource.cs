using van.Core;

namespace van.Web.Core
{
	public class WebResource : IResource
	{
		private readonly string _url;

		/// <summary>
		/// Initializes a new instance of the <see cref="WebResource"/> class.
		/// </summary>
		/// <param name="url">The URL.</param>
		public WebResource(string url)
		{
			_url = url;
		}

		/// <summary>
		/// Gets the web resource URL.
		/// </summary>
		/// <returns></returns>
		public string GetWebResourceUrl()
		{
			return _url;
		}
	}
}