using System;
using System.Collections.Generic;
using System.ServiceModel.Syndication;
using van.Core;

namespace van.ApplicationServices
{
    public class EventAggregator : IEventProvider
    {
        private readonly ISyndicationFeedRepository syndicationFeedRepository;

        public EventAggregator(ISyndicationFeedRepository syndicationFeedRepository)
        {
            this.syndicationFeedRepository = syndicationFeedRepository;
        }

        public IEnumerable<SyndicationItem> GetItems()
        {
            var feeds = new List<SyndicationItem>();
            Blog blog = new Blog();
            blog.Rss = @"http://www.google.com/calendar/feeds/9fgo89ah4shtm6pk7k5307aerg@group.calendar.google.com/public/basic";

            feeds.AddRange(syndicationFeedRepository.GetFeed(blog).Items);
            
            return feeds;
        }
    }
} ;