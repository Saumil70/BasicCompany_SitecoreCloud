using BasicCompany.Feature.Products.Models;
using GenericRazorHelpers.RazorComponentHelper;
using Sitecore.AspNet.RenderingEngine.Configuration;
using Sitecore.AspNet.RenderingEngine.Extensions;

namespace BasicCompany.Feature.Products.Extensions
{
    public static class RenderingEngineOptionsExtensions
    {
        public static RenderingEngineOptions AddFeatureProducts(this RenderingEngineOptions options)
        {
            options
                .AddModelBoundComponent<ProductList>("ProductList")
                .AddModelBoundComponent<ProductDetailHeader>("ProductDetailHeader")
                .AddModelBoundComponent<ProductDetail>("ProductDetail")
                .AddModelBoundComponent<RelatedProductsList>("RelatedProducts");
            return options;
        }
    }
}
