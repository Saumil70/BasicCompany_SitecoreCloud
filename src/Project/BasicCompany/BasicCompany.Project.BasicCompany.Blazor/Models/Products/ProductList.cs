using Sitecore.AspNet.RenderingEngine.Binding.Attributes;
using Sitecore.LayoutService.Client.Response.Model.Fields;

namespace BasicCompany.Blazor.Models.Products
{
    public class ProductList
    {
        [SitecoreComponentField]
        public ContentListField<ListProduct> Products { get; set; }
    }
}
