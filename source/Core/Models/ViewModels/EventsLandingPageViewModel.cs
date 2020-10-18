using Our.Umbraco.NonProfitFramework.Core.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Core.Models.PublishedContent;

namespace Our.Umbraco.NonProfitFramework.Core.Models.ViewModels
{
    public class EventsLandingPageViewModel : EventsLandingPage
    {
        public EventsLandingPageViewModel(IPublishedContent content) : base(content)
        {
        }

        public IOrderedEnumerable<EventItem> Events { get; set; }
    }
}
