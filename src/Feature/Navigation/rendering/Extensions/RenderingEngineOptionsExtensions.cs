using BasicCompany.Feature.Navigation.Models;
using GenericRazorHelpers.RazorComponentHelper;
using Sitecore.AspNet.RenderingEngine.Configuration;

namespace BasicCompany.Feature.Navigation.Extensions
{
    public static class RenderingEngineOptionsExtensions
    {
        public static RenderingEngineOptions AddFeatureNavigation(this RenderingEngineOptions options)
        {
            options.AddModelBoundComponent<Header>("Header")
                   .AddModelBoundComponent<Footer>("Footer");
            return options;
        }
    }
}
