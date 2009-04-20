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
        private RecordingsController controller;

        [SetUp]
        public void SetUp()
        {
            controller = new RecordingsController(CreateMockRecordingRepository());
        }

        [Test]
        public void CanListRecordings()
        {
            ViewResult result = controller.Index().AssertViewRendered();

            Assert.That(result.ViewData.Model as List<Recording>, Is.Not.Null);
            Assert.That((result.ViewData.Model as List<Recording>).Count, Is.EqualTo(4));

        }
        [Test]
        public void CanListFilteredRecordings()
        {
            

            ViewResult result =
                controller.ListRecordingsMatching("Joe")
                    .AssertViewRendered()
                    .ForView("ListRecordingMatchingFilter");

            Assert.That(result.ViewData, Is.Not.Null);
            Assert.That(result.ViewData.Model as List<Recording>,  Is.Not.Null);
            Assert.That((result.ViewData.Model as List<Recording>).Count, Is.EqualTo(4));
        }

        public IRecordingRepository CreateMockRecordingRepository()
        {
            MockRepository mocks = new MockRepository();

            IRecordingRepository mockedRepository =
                mocks.StrictMock<IRecordingRepository>();
            Expect.Call(mockedRepository.GetAll()).Return(CreateRecordings());
            Expect.Call(mockedRepository.FindAllMatching("Joe")).IgnoreArguments().Return(CreateRecordings());
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