using System.Collections.Generic;
using System.ServiceModel.Syndication;
using Google.GData.Client;
using SharpArch.Core.PersistenceSupport;
using van.ApplicationServices;
using van.Core;
using van.Core.Dto;

namespace van.Web.Controllers
{
    public class PostEventRecordViewModel : BaseViewModel
    {
        public IEnumerable<NewsDto> News { get; internal set; }
        public IEnumerable<EventDto> Events { get; internal set; }

        public static PostEventRecordViewModel CreatePostEventRecordViewModel(IAggregator aggregator)
        {
            PostEventRecordViewModel viewModel = new PostEventRecordViewModel();

            viewModel.News = aggregator.GetNews();

            viewModel.Events = aggregator.GetEvents();

            return viewModel;
        }
    }
}