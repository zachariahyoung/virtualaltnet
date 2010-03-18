using NUnit.Framework;
using van.Core;
using SharpArch.Testing;
using SharpArch.Testing.NUnit;

namespace Tests.van.Core
{
	[TestFixture]
    public class CategoryTests
    {
        [Test]
        public void CanCompareCategories() {
            Category instance = new Category();
			instance.Description = "Dependency Injection";

            Category instanceToCompareTo = new Category();
			instanceToCompareTo.Description = "Dependency Injection";

			instance.ShouldEqual(instanceToCompareTo);
        }
    }
}
