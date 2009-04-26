using NUnit.Framework;
using van.Core;
using NUnit.Framework.SyntaxHelpers;
using SharpArch.Testing;

namespace Tests.van.Core
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

            Assert.That(instance.Equals(instanceToCompareTo));
        }
    }
}
