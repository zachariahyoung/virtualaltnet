using NUnit.Framework;
using van.Core;
using SharpArch.Testing.NUnit;

namespace Tests.van.Core
{
    [TestFixture]
    public class BlogTests
    {

        [Test]
        public void CanCompareBlog()
        {
            var instance = new Blog { Name = "zach", Url = "www.cnn.com", Rss = "www.virtualaltnet.com" };

            var instanceToCompareTo = new Blog { Name = "zach", Url = "www.virtualaltnet.com", Rss = "www.virtualaltnet.com" };

            instance.ShouldEqual(instanceToCompareTo);
        }

    }
}