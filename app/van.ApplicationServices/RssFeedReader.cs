using System;
using System.Collections.Generic;
using System.ServiceModel.Syndication;
using System.Xml;

namespace van.ApplicationServices
{
    public class RssFeedReader : IRssFeedReader
    {
        public SyndicationFeed readFeed(string url)
        {
            using (XmlReader reader = XmlReader.Create(url))
            {
                SyndicationFeed rssData = SyndicationFeed.Load(reader);
                return rssData;
            }
        }
    }
}