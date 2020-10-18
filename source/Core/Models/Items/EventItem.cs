using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Our.Umbraco.NonProfitFramework.Core.Models.Items
{
    public class EventItem : BaseListItem
    {
        public string StartDate { get; set; }
        public string EndDate { get; set; }

        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Location { get; set; }
    }
}
