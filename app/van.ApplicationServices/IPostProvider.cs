using System.Collections.Generic;
using System.ServiceModel.Syndication;
using van.Core.Dto;

namespace van.ApplicationServices
{
    public interface IPostProvider
    {
        IEnumerable<SyndicationItem> GetItems();
    }
}