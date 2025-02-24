using Sitecore.Data.Items;
using System.Collections.Generic;

namespace BasicCompany.Feature.Navigation.Models
{
    public class Header
    {
        public Item HomeItem { get; set; }
        public string HomeUrl { get; set; }
        public IList<NavigationItem> NavigationItems { get; set; }
    }
}