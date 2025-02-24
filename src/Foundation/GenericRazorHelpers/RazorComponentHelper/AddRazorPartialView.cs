using Sitecore.AspNet.RenderingEngine.Configuration;
using Sitecore.AspNet.RenderingEngine.Rendering;
using Sitecore.Diagnostics;

namespace GenericRazorHelpers.RazorComponentHelper
{
    public static class RazorPartialViewExtensions
    {
        public static RenderingEngineOptions AddRazorPartialView(this RenderingEngineOptions options, string partialViewPath)
        {
            Assert.ArgumentNotNull(options, "options");
            Assert.ArgumentNotNullOrEmpty(partialViewPath, "partialViewPath");
            string layoutComponentName = ExtractComponentNameFromViewPath(partialViewPath);
            return options.AddRazorPartialView(layoutComponentName, partialViewPath);
        }

        private static string ExtractComponentNameFromViewPath(string partialViewPath)
        {
            return Path.GetFileNameWithoutExtension(partialViewPath);
        }

        public static RenderingEngineOptions AddRazorPartialView(this RenderingEngineOptions options, string layoutComponentName, string partialViewPath)
        {
            string layoutComponentName2 = layoutComponentName;
            Assert.ArgumentNotNull(options, "options");
            Assert.ArgumentNotNullOrEmpty(layoutComponentName2, "layoutComponentName");
            Assert.ArgumentNotNullOrEmpty(partialViewPath, "partialViewPath");
            return options.AddRazorPartialView((name) => layoutComponentName2.Equals(name, StringComparison.OrdinalIgnoreCase), partialViewPath);
        }

        public static RenderingEngineOptions AddRazorPartialView(this RenderingEngineOptions options, Predicate<string> match, string partialViewPath)
        {
            Assert.ArgumentNotNull(options, "options");
            Assert.ArgumentNotNull(match, "match");
            Assert.ArgumentNotNullOrEmpty(partialViewPath, "partialViewPath");
            ComponentRendererDescriptor value = PartialViewComponentRenderer.Describe(match, partialViewPath);
            options.RendererRegistry.Add(options.RendererRegistry.Count, value);
            return options;
        }
    }
}