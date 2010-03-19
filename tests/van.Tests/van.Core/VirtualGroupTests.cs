using NUnit.Framework;
using van.Core;
using SharpArch.Testing;
using SharpArch.Testing.NUnit;

namespace Tests.van.Core
{
	[TestFixture]
    public class VirtualGroupTests
    {
        [Test]
        public void CanCompareVirtualGroups() {
            Group instance = new Group();
			instance.Name = "VAN";

            Group instanceToCompareTo = new Group();
			instanceToCompareTo.Name = "VAN";

			instance.ShouldEqual(instanceToCompareTo);
        }
    }
}
