using System.Collections.Generic;

namespace BasicCompany.Blazor.Models.Products
{
    public class ProductResponse
    {
        public string UniqueId { get; set; }
        public List<string> Paths { get; set; }
        public List<string> Templates { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string ImageUrl { get; set; }
        public string ItemUrl { get; set; }
    }
}
