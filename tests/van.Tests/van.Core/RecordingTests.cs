using NUnit.Framework;
using van.Core;
using SharpArch.Testing;
using SharpArch.Testing.NUnit;

namespace Tests.van.Core
{
	[TestFixture]
    public class RecordingTests
    {
        [Test]
        public void CanCompareRecordings() {
        
            var instance = new Recording
            {
                Title = "Van Recording",
                Url = "www.virtualalt.con",
                Speaker = "Zach Young",
                UserGroup = "VAN",
                LiveMeetingUrl = "www.snipr.com/virtualaltnet.com",
                Description = "Zach talked on DDD"
            };

            var instanceToCompareTo = new Recording
            {
                Title = "Van Recording",
                Url = "www.virtualalt.con",
                Speaker = "Zach Young",
                UserGroup = "VAN",
                LiveMeetingUrl = "www.snipr.com/virtualaltnet.com",
                Description = "Zach talked on DDD"
            };

            

			instance.ShouldEqual(instanceToCompareTo);
        }
    }
}
