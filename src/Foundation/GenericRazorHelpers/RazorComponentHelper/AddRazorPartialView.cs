using Sitecore.AspNetCore.SDK.RenderingEngine.Configuration;
using Sitecore.AspNetCore.SDK.RenderingEngine.Rendering;


namespace GenericRazorHelpers.RazorComponentHelper
{
    public static class RazorPartialViewExtensions
    {
        public static RenderingEngineOptions AddRazorPartialView(this RenderingEngineOptions options, string partialViewPath)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            if (string.IsNullOrWhiteSpace(partialViewPath))
            {
                throw new ArgumentException("Partial view path cannot be null or empty", nameof(partialViewPath));
            }
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
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            if (string.IsNullOrWhiteSpace(layoutComponentName))
            {
                throw new ArgumentException("Layout component name cannot be null or empty", nameof(layoutComponentName));
            }

            if (string.IsNullOrWhiteSpace(partialViewPath))
            {
                throw new ArgumentException("Partial view path cannot be null or empty", nameof(partialViewPath));
            }
            return options.AddRazorPartialView((name) => layoutComponentName2.Equals(name, StringComparison.OrdinalIgnoreCase), partialViewPath);
        }

        public static RenderingEngineOptions AddRazorPartialView(this RenderingEngineOptions options, Predicate<string> match, string partialViewPath)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            if (match == null)
            {
                throw new ArgumentNullException(nameof(match));
            }

            if (string.IsNullOrWhiteSpace(partialViewPath))
            {
                throw new ArgumentException("Partial view path cannot be null or empty", nameof(partialViewPath));
            }
            ComponentRendererDescriptor value = PartialViewComponentRenderer.Describe(match, partialViewPath);
            options.RendererRegistry.Add(options.RendererRegistry.Count, value);
            return options;
        }
    }
}