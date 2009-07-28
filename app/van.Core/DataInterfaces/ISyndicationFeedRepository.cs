using System.ServiceModel.Syndication;


namespace van.Core
{
    public interface ISyndicationFeedRepository
    {
        SyndicationFeed GetFeed(Blog blog);
    }
}