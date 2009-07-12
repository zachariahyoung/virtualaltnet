using System.Collections.Generic;
using System.ServiceModel.Syndication;

namespace van.ApplicationServices
{
    public interface IRssFeedReader
    {
        SyndicationFeed readFeed(string url);
    }
}