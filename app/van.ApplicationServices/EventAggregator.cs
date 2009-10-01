using System.Collections.Generic;
using Google.GData.Client;
using van.Core.Dto;

namespace van.ApplicationServices
{
    /// <summary>
    /// Class for EventAggregator
    /// </summary>
    public class EventAggregator : IEventAggregator
    {
        /// <summary>
        /// Sets _eventProviders
        /// </summary>
        private readonly IEventProvider[] _eventProviders;

        /// <summary>
        /// Method that gets the events
        /// </summary>
        /// <returns>Collection of Atom Entry</returns>
        public EventAggregator(IEventProvider[] eventProviders)
        {
            _eventProviders = eventProviders;
        }

        public IEnumerable<EventDto> GetItems()
        {
            List<EventDto> eventDtos = new List<EventDto>();
            
            foreach (var provider in _eventProviders)
            {
                eventDtos.AddRange(provider.GetItems());
            }

            return eventDtos;
        }
    }
} 