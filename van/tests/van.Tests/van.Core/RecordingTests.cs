using System;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;
using van.Core;
namespace Tests.van.Core
{   
    [TestFixture]
    public class RecordingTests
    {
        [Test]
        public void CanCreateRecording()
        {
            var title = "Unit Testing";
            var url = "http://www.zachariahyoung.com";
            var date = new DateTime(2008, 3, 20);
            var duration = "1:30";
            
            var recording = new Recording();
            recording.RecordingTitle = title;
            recording.RecordingUrl = url;
            recording.RecordingDate = date;
            recording.RecordingDuration = duration;

            Assert.That(recording.RecordingTitle, Is.EqualTo(title));
            Assert.That(recording.RecordingUrl, Is.EqualTo(url));
            Assert.That(recording.RecordingDate, Is.EqualTo(date));
            Assert.That(recording.RecordingDuration, Is.EqualTo(duration));

        }

     
        [Test]
        public void CanCompareRecording()
        {
            var instance = new Recording
                               {
                                   RecordingTitle = "Joe", 
                                   RecordingUrl = "http://www.cnn.com", 
                                   RecordingDate = new DateTime(2008, 3, 20), 
                                   RecordingDuration = "1:30"
                               };

            var instanceToCompareTo = new Recording
                                          {
                                              RecordingTitle = "Joe", 
                                              RecordingUrl = "http://www.cnn.com", 
                                              RecordingDate = new DateTime(2008, 3, 20), 
                                              RecordingDuration = "1:30"
                                          };

            Assert.That(instance.Equals(instanceToCompareTo));
        }

    }
}

