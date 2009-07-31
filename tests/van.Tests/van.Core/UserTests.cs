using NUnit.Framework;
using van.Core;
using SharpArch.Testing.NUnit;

namespace Tests.van.Core
{
	[TestFixture]
    public class UserTests
    {
        [Test]
        public void CanCompareUsers() {
            var instance = new User {UserName = "JoeLouis", Password = "******"};

            var instanceToCompareTo = new User {UserName = "JoeLouis", Password = "******"};

            instance.ShouldEqual(instanceToCompareTo);
        }
    }
}
