using System.Collections.Generic;
using van.Core;
using van.Core.Dto;

namespace van.ApplicationServices.ViewModels
{
    public class EventNewsFormViewModel : BaseViewModel
    {
        public IList<NewsDto> News { get; internal set; }
        public IList<EventDto> Events { get; internal set; }        
        
    }
}