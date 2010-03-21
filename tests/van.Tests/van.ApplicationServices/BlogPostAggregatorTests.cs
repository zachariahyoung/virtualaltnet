using NUnit.Framework;
using Rhino.Mocks;
using van.ApplicationServices.ManagementService;
using van.Core;
using SharpArch.Core.PersistenceSupport;
using System.ServiceModel.Syndication;
using van.ApplicationServices;
using System.Linq;
namespace Tests.van.ApplicationServices
{
    [TestFixture]
    public class BlogPostAggregatorTests
    {
        public Group GetGroup(int id)
        {
            var b = new Group();
            SharpArch.Testing.EntityIdSetter.SetIdOf(b, id);
            return b;
        }
    
        [Test]
        public void Will_aggregate_posts_from_multiple_blogs()
        {
            var blogs = new Group[]
                            {
                                GetGroup(1), GetGroup(3),
                            };
            var blogRepo = MockRepository.GenerateStub<IGroupManagementService>();
            blogRepo.Stub(x => x.GetAll()).Return(blogs);
            var postRepo = MockRepository.GenerateStub<ISyndicationFeedRepository>();
            
            var blog0Items = new SyndicationItem[] {new SyndicationItem(),};
            postRepo.Stub(x => x.GetFeed(blogs[0])).Return(new SyndicationFeed(blog0Items)) ;
            var blog1Items = new SyndicationItem[] { new SyndicationItem(), new SyndicationItem(), };
            postRepo.Stub(x => x.GetFeed(blogs[1])).Return(new SyndicationFeed(blog1Items));

            var posts = new BlogspotNewsProvider(blogRepo, postRepo).GetItems();
            Assert.AreEqual(3, posts.Count());
            //blog0Items.ForEach(x => Assert.That(posts.Contains(x)));
            //blog1Items.ForEach(x => Assert.That(posts.Contains(x)));
        }

    }
}