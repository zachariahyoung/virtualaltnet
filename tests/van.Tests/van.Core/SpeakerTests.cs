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
			instance.FirstName = "Joe";
			instance.LastName = "Smith";
			instance.Email = "JoeSmith@gmail.com";

            Speaker instanceToCompareTo = new Speaker();
			instanceToCompareTo.FirstName = "Joe";
			instanceToCompareTo.LastName = "Smith";
			instanceToCompareTo.Email = "JoeSmith@gmail.com";

			instance.ShouldEqual(instanceToCompareTo);
        }
    }
}
