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

        


        #endregion
    }
}