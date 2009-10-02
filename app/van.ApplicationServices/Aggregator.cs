using System.Collections.Generic;
using Google.GData.Client;
using van.Core.Dto;

namespace van.ApplicationServices
{
    /// <summary>
    /// Class for Aggregator
    /// </summary>
    public class Aggregator : IAggregator
    {
        /// <summary>
        /// Sets _eventProviders
        /// </summary>
        private readonly IEventProvider[] _eventProviders;
        private readonly INewsProvider[] _newsProviders;

        /// <summary>
        /// Method that gets the events
        /// </summary>
        /// <returns>Collection of Atom Entry</returns>
        public Aggregator(IEventProvider[] eventProviders, INewsProvider[] newsProviders) 
        {
            _eventProviders = eventProviders;
            _newsProviders = newsProviders;
        }

        public IEnumerable<EventDto> GetEvents()
        {
            List<EventDto> eventDtos = new List<EventDto>();
            
            foreach (var provider in _eventProviders)
            {
                eventDtos.AddRange(provider.GetItems());
            }

            return eventDtos;
        }

        public IEnumerable<NewsDto> GetNews()
        {
            List<NewsDto> eventDtos = new List<NewsDto>();

            foreach (var provider in _newsProviders)
            {
                eventDtos.AddRange(provider.GetItems());
            }

            return eventDtos;
        }

    }
} 