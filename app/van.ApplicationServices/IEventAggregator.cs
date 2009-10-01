using System.Collections.Generic;
using van.Core.Dto;

namespace van.ApplicationServices
{
    public interface IEventAggregator
    {
        IEnumerable<EventDto> GetItems();
    }
}