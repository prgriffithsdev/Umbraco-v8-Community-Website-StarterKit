using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Our.Umbraco.NonProfitFramework.Core.Models.Items
{
    public class BaseListItem
    {
        public string Heading { get; set; }
        public IHtmlString Excerpt { get; set; }
        public string Url { get; set; }
        public string ImageUrl { get; set; }
    }
}
