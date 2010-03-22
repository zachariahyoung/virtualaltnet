using System.Collections.Generic;
using van.ApplicationServices.ViewModels;
using van.Core.Dto;

namespace van.ApplicationServices
{
    public interface IAggregator
    {
        EventDto[] GetEvents();
        NewsDto[] GetNews();
        EventNewsFormViewModel GetEventNews();

    }
}