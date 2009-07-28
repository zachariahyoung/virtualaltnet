using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Xml;
using SharpArch.Core.PersistenceSupport;
using van.Core;


using van.Core.Dto;

namespace van.ApplicationServices
{
    public class BlogPostAggregator : IPostProvider
    {
        private readonly IRepository<Blog> blogRepository;
        private readonly ISyndicationFeedRepository syndicationFeedRepository;

        public BlogPostAggregator(IRepository<Blog> blogRepository, ISyndicationFeedRepository syndicationFeedRepository)
        {
            this.blogRepository = blogRepository;
            this.syndicationFeedRepository = syndicationFeedRepository;
        }

        #region IPostProvider Members

        public IEnumerable<SyndicationItem> GetItems()
        {
            IList<Blog> query = blogRepository.GetAll();

            var feeds = new List<SyndicationItem>();

            foreach (Blog blog in query)
            {
                feeds.AddRange(syndicationFeedRepository.GetFeed(blog).Items);
            }


            return feeds;
        }

        

        private IEnumerable<PostDto> GetMashedItems(List<SyndicationFeed> feeds, int cnt)
        {
            return (from feed in feeds
                   from item in feed.Items
                   orderby item.PublishDate descending
                   select new PostDto
                              {
                                  Url = item.Links[4].Uri.OriginalString,
                                  Title = item.Title.Text,
                                  Date = item.PublishDate.Date.ToShortDateString(),
                                  Content = ((System.ServiceModel.Syndication.TextSyndicationContent) (item.Content)).Text
                              }).Take(cnt);
        }

        #endregion
    }
}