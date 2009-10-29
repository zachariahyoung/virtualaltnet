using System.Collections.Generic;
using System.ServiceModel.Syndication;
using Google.GData.Client;
using van.Core.Dto;

namespace van.ApplicationServices
{
    public interface IEventProvider
    {
        EventDto[] GetItems();
    }
}