using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using Google.GData.Calendar;
using Google.GData.Client;
using van.Core.Dto;

namespace van.Core
{
    public static class SyndicationItemExtension
    {
        public static IEnumerable<PostDto> FindTopPost(this IEnumerable<SyndicationItem> items, int cnt)
        {
            return (from item in items
                   orderby item.PublishDate descending
                   select new PostDto
                   {
                       Url = item.Links[4].Uri.OriginalString,
                       Title = item.Title.Text,
                       Date = item.PublishDate.Date.ToShortDateString(),
                       Content = ((System.ServiceModel.Syndication.TextSyndicationContent)item.Content).Text
                   }).Take(cnt);
        }
        
    }
}