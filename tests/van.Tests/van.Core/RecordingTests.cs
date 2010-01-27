using NUnit.Framework;
using van.Core;
using SharpArch.Testing;
using SharpArch.Testing.NUnit;

namespace Tests.van.Core
{
	[TestFixture]
    public class RecordingTests
    {
        [Test]
        public void CanCompareRecordings() {
            Recording instance = new Recording();
			instance.Date = DateTime.Parse("01/27/2010");
			instance.UploadedUrl = "http://www.viddler.com/explore/virtualaltnet/videos/1";

            Recording instanceToCompareTo = new Recording();
			instanceToCompareTo.Date = DateTime.Parse("01/27/2010");
			instanceToCompareTo.UploadedUrl = "http://www.viddler.com/explore/virtualaltnet/videos/1";

			instance.ShouldEqual(instanceToCompareTo);
        }
    }
}
