using BasicCompany.Blazor.Models.BasicContent;
using BasicCompany.Blazor.Models.Navigation;
using BasicCompany.Blazor.Models.Products;
using BasicCompany.Blazor.Models.Services;
using GenericRazorHelpers.RazorComponentHelper;
using Sitecore.AspNet.RenderingEngine.Configuration;

namespace BasicCompany.Blazor.Extensions
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

        public static RenderingEngineOptions AddFeatureNavigation(this RenderingEngineOptions options)
        {
            options.AddModelBoundComponent<Header>("Header")
                   .AddModelBoundComponent<Footer>("Footer");
            return options;
        }

        public static RenderingEngineOptions AddFeatureProducts(this RenderingEngineOptions options)
        {
            options
                .AddModelBoundComponent<ProductList>("ProductList")
                .AddModelBoundComponent<ProductDetailHeader>("ProductDetailHeader")
                .AddModelBoundComponent<ProductDetail>("ProductDetail")
                .AddModelBoundComponent<RelatedProductsList>("RelatedProducts");
            return options;
        }

        public static RenderingEngineOptions AddFeatureServices(this RenderingEngineOptions options)
        {
            options
                .AddRazorPartialView("TestimonialContainer")
                .AddModelBoundComponent<Testimonial>("Testimonial")
                .AddRazorPartialView("Accordion")
                .AddModelBoundComponent<AccordionItem>("AccordionItem");
            return options;
        }
    }
}
