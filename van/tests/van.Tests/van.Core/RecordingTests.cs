using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;
using van.Core;
namespace Tests.van.Core
{   
    [TestFixture]
    public class RecordingTests
    {
        [Test]
        public void CanCreateRecording()
        {
            string title = "Unit Testing";
            string url = "http://www.zachariahyoung.com";

            Recording recording = new Recording();
            recording.RecordingTitle = title;
            recording.RecordingUrl = url;

            Assert.That(recording.RecordingTitle, Is.EqualTo(title));

        }

        [Ignore]
        [Test]
        public void CanCompareRecording()
        {
            Recording instance = new Recording();
            instance.RecordingTitle = "Joe";
            instance.RecordingUrl = "http://www.cnn.com";

            Recording instanceToCompareTo = new Recording();
            instanceToCompareTo.RecordingTitle = "Joe";
            instanceToCompareTo.RecordingUrl = "http://www.cnn.com";

            Assert.That(instance.Equals(instanceToCompareTo));
        }

    }
}

