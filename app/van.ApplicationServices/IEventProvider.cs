using System.Collections.Generic;
using System.ServiceModel.Syndication;

namespace van.ApplicationServices
{
    public interface IEventProvider
    {
        IEnumerable<SyndicationItem> GetItems();
    }
}