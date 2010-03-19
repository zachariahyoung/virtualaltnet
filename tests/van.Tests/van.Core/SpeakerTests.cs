using NUnit.Framework;
using van.Core;
using SharpArch.Testing;
using SharpArch.Testing.NUnit;

namespace Tests.van.Core
{
	[TestFixture]
    public class SpeakerTests
    {
        [Test]
        public void CanCompareSpeakers() {
            Speaker instance = new Speaker();
			instance.Name = "Joe Smith";

			instance.Email = "JoeSmith@gmail.com";

            Speaker instanceToCompareTo = new Speaker();
			instanceToCompareTo.Name = "Joe Smith";
			instanceToCompareTo.Email = "JoeSmith@gmail.com";

			instance.ShouldEqual(instanceToCompareTo);
        }
    }
}
