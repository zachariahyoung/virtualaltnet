namespace van.Web.Core.Configuration
{
	public class AppSettings : IAppSettings
	{
		// ReSharper disable InconsistentNaming
		const string _contentFiles = "contentFiles";
		// ReSharper restore InconsistentNaming

		public string ContentFiles
		{
			get { return _contentFiles; }
		}
	}
}