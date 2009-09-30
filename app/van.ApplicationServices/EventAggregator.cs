using System;
using System.Collections.Generic;
using System.ServiceModel.Syndication;
using van.Core;
//using Google.GData.Extensions;
using Google.GData.Calendar;
using Google.GData.Client;


namespace van.ApplicationServices
{
    public class EventAggregator : IEventProvider
    {

        public AtomEntryCollection GetItems()
        {
            EventQuery query = new EventQuery();
            CalendarService service = new CalendarService("Virtual ALT.NET calendar");

            query.Uri = new Uri(@"http://www.google.com/calendar/feeds/9fgo89ah4shtm6pk7k5307aerg@group.calendar.google.com/public/full");
            query.StartTime = DateTime.Now;
            query.EndTime = DateTime.Now.AddMonths(3);
            query.ExtraParameters = "orderby=starttime&sortorder=ascending";
            //query.FutureEvents = true;
            //query.SortOrder = CalendarSortOrder.descending;
            EventFeed calFeed = service.Query(query) as EventFeed;

            return calFeed.Entries;
        }
    }
} ;