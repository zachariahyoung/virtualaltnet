using System.Collections.Generic;
using van.Core.Dto;

namespace van.ApplicationServices
{
    public interface IAggregator
    {
        IEnumerable<EventDto> GetEvents();
        IEnumerable<NewsDto> GetNews();

    }
}