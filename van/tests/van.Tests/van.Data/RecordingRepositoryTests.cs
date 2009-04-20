using System;
using System.Collections.Generic;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;
using SharpArch.Testing.NUnit.NHibernate;
using van.Core.DataInterfaces;
using van.Core;
using van.Data;

namespace Tests.van.Data
{
    [TestFixture]
    [Category("DB Tests")]
    public class RecordingRepositoryTests : RepositoryTestsBase
    {
        private IRecordingRepository recordingRepository = new RecordingRepository();

        protected override void LoadTestData()
        {
            AddRecording("Joe", "http://www.zachariahyoung.com/", new DateTime(2008, 3, 20), "1:30");
            AddRecording("Jed", "http://www.zachariahyoung.com/", new DateTime(2008, 3, 20), "1:30");
            AddRecording("Jot", "http://www.zachariahyoung.com/", new DateTime(2008, 3, 20), "1:30");
            AddRecording("Jay", "http://www.zachariahyoung.com/", new DateTime(2008, 3, 20), "1:30");
        }

        private void AddRecording(string name, string url, DateTime date, string duration)
        {
            var recording = new Recording()
                                {
                                    RecordingTitle = name, 
                                    RecordingUrl = url,
                                    RecordingDate = date,
                                    RecordingDuration = duration
 
                                };

            recordingRepository.SaveOrUpdate(recording);
            FlushSessionAndEvict(recording);


        }

        [Test]
        public void CanLoadRecordingsMatchingFilter()
        {
            var matchingRecording = recordingRepository.FindAllMatching("Joe");

            Assert.That(matchingRecording.Count, Is.EqualTo(1));
            
        }
    }
}