using NUnit.Framework;
using zach.Core;
using SharpArch.Testing;
using SharpArch.Testing.NUnit;

namespace Tests.zach.Core
{
	[TestFixture]
    public class RecordingTests
    {
        [Test]
        public void CanCompareRecordings() {
            Recording instance = new Recording();
			instance.RecordingTitle = "Van Recording";
			instance.RecordingUrl = "Location of Recording";

            Recording instanceToCompareTo = new Recording();
			instanceToCompareTo.RecordingTitle = "Van Recording";
			instanceToCompareTo.RecordingUrl = "Location of Recording";

			instance.ShouldEqual(instanceToCompareTo);
        }
    }
}
