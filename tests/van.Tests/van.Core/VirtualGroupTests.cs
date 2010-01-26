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
            VirtualGroup instance = new VirtualGroup();
			instance.GroupName = "VAN";

            VirtualGroup instanceToCompareTo = new VirtualGroup();
			instanceToCompareTo.GroupName = "VAN";

			instance.ShouldEqual(instanceToCompareTo);
        }
    }
}
