using System.Collections.Generic;
using System.ServiceModel.Syndication;
using NUnit.Framework;
using van.ApplicationServices;

namespace Tests.van.ApplicationServices
{
    [TestFixture]
    [Category("Web Integration Tests")]
    public class RssFeedReaderTest
    {
        [Test]
        public void ReadFeedTest()
        {
            
            var rssFeedReader = new RssFeedReader();

            var item = rssFeedReader.readFeed("http://feeds.feedburner.com/VirtualAltnet?format=xml");


        }

    }
}