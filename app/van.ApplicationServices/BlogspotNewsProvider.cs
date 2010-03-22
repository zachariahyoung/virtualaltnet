using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Xml;
using SharpArch.Core.PersistenceSupport;
using van.ApplicationServices.ManagementService;
using van.Core;


using van.Core.Dto;

namespace van.ApplicationServices
{
    public class BlogspotNewsProvider : INewsProvider
    {
        private readonly IGroupManagementService groupManagementService;
        private readonly ISyndicationFeedRepository syndicationFeedRepository;

        public BlogspotNewsProvider(IGroupManagementService groupManagementService, ISyndicationFeedRepository syndicationFeedRepository)
        {
            this.groupManagementService = groupManagementService;
            this.syndicationFeedRepository = syndicationFeedRepository;
        }

        public NewsDto[] GetItems()
        {
            var feeds = new List<SyndicationItem>();

            try
            {
                IList<Group> query = groupManagementService.GetAll();

                foreach (Group group in query)
                {
                    if (!group.Rss.Equals(""))
                    {
                        feeds.AddRange(syndicationFeedRepository.GetFeed(group).Items);                        
                    }

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