using Our.Umbraco.NonProfitFramework.Core.Constants;
using Our.Umbraco.NonProfitFramework.Core.Models;
using Our.Umbraco.NonProfitFramework.Core.Models.Items;
using Our.Umbraco.NonProfitFramework.Core.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Core;
using Umbraco.Web;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;

/// <summary>
/// If you need complete control over how your pages are rendered then Hijacking Umbraco Routes is for you.
/// https://our.umbraco.com/documentation/Reference/Routing/custom-controllers
/// </summary>
namespace Our.Umbraco.NonProfitFramework.Core.Controllers
{
    public class EventsLandingPageController : RenderMvcController
    {
        //[DI] i think we will eventually end up injecting the setting node
        //into here to control things such as paging amount from the CMS 

        public override ActionResult Index(ContentModel model)
        {
            if (!(model.Content is EventsLandingPage eventLandingPage))
                return null;

            //do all the date formatting and assign values from eventLandingPage.Children.OfType<EventPage>() etc
            var eventItems = BuildEventItems(eventLandingPage);

            var eventsLandingPageViewModel = new EventsLandingPageViewModel(eventLandingPage)
            {
                Events = eventItems
            };
            
            return CurrentTemplate(eventsLandingPageViewModel);
        }

        private IOrderedEnumerable<EventItem> BuildEventItems(EventsLandingPage eventLandingPage)
        {
            var eventItems = new List<EventItem>();
            var startDate = string.Empty;
            var startTime = string.Empty;
            var endDate = string.Empty;
            var endTime = string.Empty;

            foreach (var item in eventLandingPage.Children.OfType<EventPage>())
            {
                var heading = !string.IsNullOrEmpty(item.Heading) ? item.Heading : item.Name;
                var imageUrl = item.Image != null ? Url.GetCropUrl(item, "pageImage", "listingImage").ToString() : Global.PlaceholderImage.EventListingImage;

                //format these dates and times to whatever is required for presentation
                if (item.StartDate != null && item.StartDate != DateTime.MinValue)
                {
                    startDate = item.StartDate.ToString("MMMM dd yyyy");
                    startTime = item.StartDate.ToString("hh:mm");
                }
                if (item.StartDate != null && item.StartDate != DateTime.MinValue)
                {
                    endDate = item.EndDate.ToString("MMMM dd");
                    endTime = item.EndDate.ToString("hh:mm");
                }

                //this is block list(!) so need to pull an except out somehow
                var excerpt = new HtmlString("this is a small excerpt for an event that will be truncated...");

                var eventItem = new EventItem()
                {
                    Heading = heading,
                    Excerpt = excerpt,
                    ImageUrl = imageUrl,
                    StartDate = startDate,
                    EndDate = endDate,
                    StartTime = startTime,
                    EndTime = endTime
                };

                eventItems.Add(eventItem);
            }

            return eventItems.OrderBy(x => x.StartDate);
        }
    }
}