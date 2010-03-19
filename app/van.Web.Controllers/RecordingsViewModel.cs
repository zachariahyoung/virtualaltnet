using System.Collections.Generic;
using van.Core;

namespace van.Web.Controllers
{
	public class RecordingsViewModel : BaseViewModel
	{
		public Recording SingleRecording { get; set; }

		public IList<Recording> Recordings { get; set; }
	}
}