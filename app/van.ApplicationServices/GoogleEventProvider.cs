using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Google.GData.Calendar;
using Google.GData.Client;
using van.Core.Dto;

namespace van.ApplicationServices
{
    public class GoogleEventProvider : IEventProvider
    {
        public IEnumerable<EventDto> GetItems()
        {
            EventQuery query = new EventQuery();
            CalendarService service = new CalendarService("Virtual ALT.NET calendar");

            query.Uri = new Uri(@"http://www.google.com/calendar/feeds/9fgo89ah4shtm6pk7k5307aerg@group.calendar.google.com/public/full");
            query.StartTime = DateTime.Now;
            query.EndTime = DateTime.Now.AddMonths(3);
            query.SingleEvents = true;
            query.ExtraParameters = "orderby=starttime&sortorder=ascending";
            EventFeed calFeed = service.Query(query);
            
            IEnumerable<EventDto> eventDtos = this.GetEventDtos(calFeed.Entries.OfType<EventEntry>());

            return eventDtos;

        }

        private IEnumerable<EventDto> GetEventDtos(IEnumerable<EventEntry> eventEntries)
        {
            return (from item in eventEntries
                    select new EventDto
                               {
                                   Url = item.AlternateUri.ToString(),
                                   Title = item.Title.Text,
                                   Date = item.Times[0].StartTime.ToShortDateString()
                               }).Take(10);
        }
    }
}
