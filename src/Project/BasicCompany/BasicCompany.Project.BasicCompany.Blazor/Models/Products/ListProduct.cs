using Sitecore.AspNetCore.SDK.LayoutService.Client.Response.Model.Fields;

namespace BasicCompany.Blazor.Models.Products
{
    public class ListProduct
    {
        public TextField Title { get; set; }

        public TextField ShortDescription { get; set; }

        public ImageField Image { get; set; }
    }
}
