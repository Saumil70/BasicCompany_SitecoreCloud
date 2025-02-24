using BasicCompany.Feature.Services.Models;
using GenericRazorHelpers.RazorComponentHelper;
using Sitecore.AspNet.RenderingEngine.Configuration;
using Sitecore.AspNet.RenderingEngine.Extensions;

namespace BasicCompany.Feature.Products.Extensions
{
    public static class RenderingEngineOptionsExtensions
    {
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
