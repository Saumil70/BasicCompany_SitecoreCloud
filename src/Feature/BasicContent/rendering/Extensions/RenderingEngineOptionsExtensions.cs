using BasicCompany.Feature.BasicContent.Models;
using GenericRazorHelpers.RazorComponentHelper;
using Sitecore.AspNet.RenderingEngine.Configuration;

namespace BasicCompany.Feature.BasicContent.Extensions
{
    public static class RenderingEngineOptionsExtensions
    {
        public static RenderingEngineOptions AddFeatureBasicContent(this RenderingEngineOptions options)
        {
            options
                .AddModelBoundComponent<PromoCard>("PromoCard")
                .AddRazorPartialView("PromoContainer")
                .AddModelBoundComponent<SectionHeader>("SectionHeader")
                .AddModelBoundComponent<HeroBannerModel>("HeroBanner")
                .AddModelBoundComponent<FrontProduct>("FrontProduct");
            return options;
        }
    }
}
