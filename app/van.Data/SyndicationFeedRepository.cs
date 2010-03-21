using System;
using System.ServiceModel.Syndication;
using System.Xml;
using van.Core;

namespace van.Data
{


    public class SyndicationFeedRepository : ISyndicationFeedRepository
    {
        public SyndicationFeed GetFeed(Group group)
        {
            using (XmlReader reader = XmlReader.Create(group.Rss))
            {
                try
                {
                    return SyndicationFeed.Load(reader);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}