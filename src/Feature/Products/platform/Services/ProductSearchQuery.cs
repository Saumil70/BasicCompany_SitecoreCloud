using Sitecore.ContentSearch;
using Sitecore.Data;
using System.Collections.Generic;

namespace BasicCompany.Feature.Products.Services
{
    public class ProductSearchQuery
    {
        [IndexField("_uniqueid")]
        public virtual ItemUri UniqueId { get; set; }
        [IndexField("_path")]
        public virtual IEnumerable<ID> Paths { get; set; }
        [IndexField("_templates")]
        public virtual IEnumerable<ID> Templates { get; set; }
        [IndexField("title_t")]
        public virtual string Title { get; set; }
        [IndexField("_name")]
        public virtual string Name { get; set; }
        [IndexField("shortdescription_t")]
        public virtual string ShortDescription { get; set; }
        public string ImageUrl { get; set; }
        public string ItemUrl { get; set; }
    }
}