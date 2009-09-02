using System.Collections.Generic;
using System.ServiceModel.Syndication;
using SharpArch.Core.PersistenceSupport;
using van.ApplicationServices;
using van.Core;
using van.Core.Dto;

namespace van.Web.Controllers
{
    public class PostEventRecordViewModel
    {
        private PostEventRecordViewModel() { }

        public static PostEventRecordViewModel CreatePostEventRecordViewModel(IPostProvider postProvider, IEventProvider eventProvider, IRepository<Recording> recordingRepository)
        {
            PostEventRecordViewModel viewModel = new PostEventRecordViewModel();

            //viewModel.Recordings = recordingRepository.GetAll();

            IEnumerable<SyndicationItem> posts = postProvider.GetItems();

            viewModel.Posts = posts.FindItemsTop(15);
            
            IEnumerable<SyndicationItem> events = eventProvider.GetItems();

            //viewModel.Events = events.FindItemsTop(15);

            return viewModel;
        }

        public IList<Recording> Recordings { get; internal set; }
        public IEnumerable<PostDto> Posts { get; internal set; }
        public IEnumerable<EventDto> Events { get; internal set; }

    }
}