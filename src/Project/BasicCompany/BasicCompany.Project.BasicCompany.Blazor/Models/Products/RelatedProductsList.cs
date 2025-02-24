using Sitecore.AspNetCore.SDK.LayoutService.Client.Response.Model.Fields;

namespace BasicCompany.Blazor.Models.Products
{
    public class RelatedProductsList
    {
        public ContentListField<ListProduct> RelatedProducts { get; set; }
    }
}