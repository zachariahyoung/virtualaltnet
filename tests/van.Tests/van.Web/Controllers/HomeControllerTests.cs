using NUnit.Framework;
using Rhino.Mocks;
using van.ApplicationServices;

namespace Tests.van.Web.Controllers
{
    [TestFixture]
    public class HomeControllerTests
    {

        [Test]
        public void CanListItems()
        {
            

        }

        private IPostProvider CreateMockPostProvider()
        {
            IPostProvider postProvider = MockRepository.GenerateMock<IRepository<Blog> blogRepository, ISyndicationFeedRepository syndicationFeedRepository>();
        }
    }
}