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
            AddRecording("Joe", "http://www.cnn.com");
            AddRecording("Jed", "http://www.cnn.com");
            AddRecording("Jot", "http://www.cnn.com");
            AddRecording("Jay", "http://www.cnn.com");
        }

        private void AddRecording(string name, string url)
        {
            var recording = new Recording() {RecordingTitle = name, RecordingUrl = url};

            recordingRepository.SaveOrUpdate(recording);
            FlushSessionAndEvict(recording);


        }

        [Test]
        public void CanLoadRecordingsMatchingFilter()
        {
            List<Recording> matchingRecording = recordingRepository.FindAllMatching("Joe");

            Assert.That(matchingRecording.Count, Is.EqualTo(1));
            
        }
    }
}