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
			instance.Title = "Van Recording";
			instance.Url = "Location of Recording";

            Recording instanceToCompareTo = new Recording();
			instanceToCompareTo.Title = "Van Recording";
			instanceToCompareTo.Url = "Location of Recording";

			instance.ShouldEqual(instanceToCompareTo);
        }
    }
}
