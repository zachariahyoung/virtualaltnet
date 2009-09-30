using System;
using Google.GData.Calendar;
using Google.GData.Client;

namespace van.ApplicationServices
{
    /// <summary>
    /// Class for EventAggregator
    /// </summary>
    public class EventAggregator : IEventProvider
    {
        /// <summary>
        /// Method that gets the event
        /// </summary>
        /// <returns>Collection of Atom Entry</returns>
        public AtomEntryCollection GetItems()
        {
            EventQuery query = new EventQuery();
            CalendarService service = new CalendarService("Virtual ALT.NET calendar");

            query.Uri = new Uri(@"http://www.google.com/calendar/feeds/9fgo89ah4shtm6pk7k5307aerg@group.calendar.google.com/public/full");
            query.StartTime = DateTime.Now;
            query.EndTime = DateTime.Now.AddMonths(3);
            query.SingleEvents = true;
            query.ExtraParameters = "orderby=starttime&sortorder=ascending";
            EventFeed calFeed = service.Query(query);

            return calFeed.Entries;
        }
    }
} 