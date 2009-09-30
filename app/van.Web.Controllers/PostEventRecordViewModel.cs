using System.Collections.Generic;
using System.ServiceModel.Syndication;
using Google.GData.Client;
using SharpArch.Core.PersistenceSupport;
using van.ApplicationServices;
using van.Core;
using van.Core.Dto;

namespace van.Web.Controllers
{
    public class PostEventRecordViewModel
    {
        public IList<Recording> Recordings { get; internal set; }
        public IEnumerable<PostDto> Posts { get; internal set; }
        public IEnumerable<EventDto> Events { get; internal set; }

        public static PostEventRecordViewModel CreatePostEventRecordViewModel(IPostProvider postProvider, IEventProvider eventProvider, IRepository<Recording> recordingRepository)
        {
            PostEventRecordViewModel viewModel = new PostEventRecordViewModel();

            IEnumerable<SyndicationItem> posts = postProvider.GetItems();

            viewModel.Posts = posts.FindTopPost(15);

            AtomEntryCollection events = eventProvider.GetItems();

            viewModel.Events = events.FindTopEvent(10);

            return viewModel;
        }
    }
}