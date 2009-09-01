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
            
        }
    }
}