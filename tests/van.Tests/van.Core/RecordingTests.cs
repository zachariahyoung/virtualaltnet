using System;
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
                                   Date = DateTime.Parse("01/27/2010"),
                                   Url = "http://www.viddler.com/explore/virtualaltnet/videos/1"
                               };

            var instanceToCompareTo = new Recording
                                          {
                                              Date = DateTime.Parse("01/27/2010"),
                                              Url = "http://www.viddler.com/explore/virtualaltnet/videos/1"
                                          };

            instance.ShouldEqual(instanceToCompareTo);
        }
    }
}
