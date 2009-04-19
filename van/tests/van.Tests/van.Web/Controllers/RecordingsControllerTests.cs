using System.Collections.Generic;
using System.Web.Mvc;
using MvcContrib.TestHelper;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;
using Rhino.Mocks;
using van.Core;
using van.Core.DataInterfaces;
using van.Web.Controllers;

namespace Tests.van.Web.Controllers
{
    [TestFixture]
    public class RecordingsControllerTests
    {
        [Test]
        public void CanListFilteredRecordings()
        {
            RecordingsController controller = 
                new RecordingsController(CreateMockRecordingRepository());

            ViewResult result =
                controller.ListRecordingsMatching("test")
                    .AssertViewRendered()
                    .ForView("ListRecoringsMatchingFilter");

            Assert.That(result.ViewData, Is.Not.Null);
            Assert.That(result.ViewData.Model as List<Recording>,  Is.Not.Null);
            Assert.That((result.ViewData.Model as List<Recording>).Count, Is.EqualTo(4));
        }

        public IRecordingRepository CreateMockRecordingRepository()
        {
            MockRepository mocks = new MockRepository();

            IRecordingRepository mockedRepository =
                mocks.StrictMock<IRecordingRepository>();
            Expect.Call(mockedRepository.FindAllMatching(null)).IgnoreArguments().Return(CreateRecordings());
            mocks.Replay(mockedRepository);

            return mockedRepository;

        }

        private List<Recording> CreateRecordings()
        {
            List<Recording> recordings =
                new List<Recording>();

            
            recordings.Add(new Recording { RecordingTitle = "Joe", RecordingUrl = "http://www.cnn.com"});
            recordings.Add(new Recording { RecordingTitle = "Joe", RecordingUrl = "http://www.cnn.com" });
            recordings.Add(new Recording { RecordingTitle = "Joe", RecordingUrl = "http://www.cnn.com" });
            recordings.Add(new Recording { RecordingTitle = "Joe", RecordingUrl = "http://www.cnn.com" });

            return recordings;
        }
    }
}