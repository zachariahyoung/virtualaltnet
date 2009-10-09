using System.Collections.Generic;
using van.Core.Dto;

namespace van.ApplicationServices
{
    public interface IAggregator
    {
        EventDto[] GetEvents();
        NewsDto[] GetNews();

    }
}