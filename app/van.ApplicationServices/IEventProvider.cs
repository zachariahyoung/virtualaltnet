using System.Collections.Generic;
using System.ServiceModel.Syndication;
using Google.GData.Client;

namespace van.ApplicationServices
{
    public interface IEventProvider
    {
        AtomEntryCollection GetItems();
    }
}