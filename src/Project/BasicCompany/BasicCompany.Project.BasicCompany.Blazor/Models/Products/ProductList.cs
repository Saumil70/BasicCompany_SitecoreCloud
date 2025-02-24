using Sitecore.AspNetCore.SDK.RenderingEngine.Binding.Attributes;
using Sitecore.AspNetCore.SDK.LayoutService.Client.Response.Model.Fields;

namespace BasicCompany.Blazor.Models.Products
{
    public class ProductList
    {
        [SitecoreComponentField]
        public ContentListField<ListProduct> Products { get; set; }
    }
}
