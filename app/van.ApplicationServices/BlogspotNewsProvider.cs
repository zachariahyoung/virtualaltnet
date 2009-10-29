using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Xml;
using SharpArch.Core.PersistenceSupport;
using van.Core;


using van.Core.Dto;

namespace van.ApplicationServices
{
    public class BlogspotNewsProvider : INewsProvider
    {
        private readonly IRepository<Blog> blogRepository;
        private readonly ISyndicationFeedRepository syndicationFeedRepository;

        public BlogspotNewsProvider(IRepository<Blog> blogRepository, ISyndicationFeedRepository syndicationFeedRepository)
        {
            this.blogRepository = blogRepository;
            this.syndicationFeedRepository = syndicationFeedRepository;
        }

        public NewsDto[] GetItems()
        {
            var feeds = new List<SyndicationItem>();

            try
            {
                IList<Blog> query = blogRepository.GetAll();

                foreach (Blog blog in query)
                {
                    feeds.AddRange(syndicationFeedRepository.GetFeed(blog).Items);
                }

                return this.GetNewsDtos(feeds);
            }
            catch (Exception)
            {
                
                return new NewsDto[0];
            }

        }

        private NewsDto[] GetNewsDtos(IEnumerable<SyndicationItem> items)
        {
            return (from item in items
                    orderby item.PublishDate descending
                    select new NewsDto
                    {
                        Url = item.Links[4].Uri.OriginalString,
                        Title = item.Title.Text,
                        Date = item.PublishDate.Date.ToShortDateString(),
                        Content = ((System.ServiceModel.Syndication.TextSyndicationContent)item.Content).Text
                    }).Take(10).ToArray();
        }
        
    }
}