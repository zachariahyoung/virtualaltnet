using System;
using NUnit.Framework;
using van.Core;
using SharpArch.Testing;
using SharpArch.Testing.NUnit;

namespace Tests.van.Core
{
	[TestFixture]
    public class UpcomingEventTests
    {
        [Test]
        public void CanCompareUpcomingEvents() {
            UpcomingEvent instance = new UpcomingEvent();
			instance.Title = "A night with Groucho Marx";
			instance.EventDate = DateTime.Parse("01/26/2010");

            UpcomingEvent instanceToCompareTo = new UpcomingEvent();
			instanceToCompareTo.Title = "A night with Groucho Marx";
			instanceToCompareTo.EventDate = DateTime.Parse("01/26/2010");

			instance.ShouldEqual(instanceToCompareTo);
        }
    }
}
