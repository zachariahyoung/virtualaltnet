using NUnit.Framework;
using van.Core;
using SharpArch.Testing;
using SharpArch.Testing.NUnit;

namespace Tests.van.Core
{
	[TestFixture]
    public class StatusTests
    {
        [Test]
        public void CanCompareStatuses() {
            Status instance = new Status();
			instance.Name = "Active";

            Status instanceToCompareTo = new Status();
			instanceToCompareTo.Name = "Active";

			instance.ShouldEqual(instanceToCompareTo);
        }
    }
}
