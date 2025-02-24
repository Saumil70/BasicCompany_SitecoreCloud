using Sitecore.AspNet.RenderingEngine.Configuration;
using Sitecore.AspNet.RenderingEngine.Rendering;

namespace GenericRazorHelpers.RazorComponentHelper
{
    public static class CustomRenderingEngineOptionsExtensions
    {
        public static RenderingEngineOptions AddModelBoundComponent<TModel>(this RenderingEngineOptions options, string componentName)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            if (string.IsNullOrEmpty(componentName))
            {
                throw new ArgumentException("Component name cannot be null or empty.", nameof(componentName));
            }

            return options.AddModelBoundComponent<TModel>(ExtractComponentNameFromViewPath(componentName), componentName);
        }

        private static string ExtractComponentNameFromViewPath(string partialViewPath)
        {
            if (string.IsNullOrEmpty(partialViewPath))
            {
                throw new ArgumentException("Partial view path cannot be null or empty.", nameof(partialViewPath));
            }

            return Path.GetFileNameWithoutExtension(partialViewPath);
        }

        public static RenderingEngineOptions AddModelBoundComponent<TModel>(this RenderingEngineOptions options, string layoutComponentName, string componentName)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            if (string.IsNullOrEmpty(layoutComponentName))
            {
                throw new ArgumentException("Layout component name cannot be null or empty.", nameof(layoutComponentName));
            }

            if (string.IsNullOrEmpty(componentName))
            {
                throw new ArgumentException("Component name cannot be null or empty.", nameof(componentName));
            }

            return options.AddModelBoundComponent<TModel>(match => match.Equals(layoutComponentName, StringComparison.OrdinalIgnoreCase), componentName);
        }

        public static RenderingEngineOptions AddModelBoundComponent<TModel>(this RenderingEngineOptions options, Predicate<string> match, string componentName)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            if (match == null)
            {
                throw new ArgumentNullException(nameof(match));
            }

            if (string.IsNullOrEmpty(componentName))
            {
                throw new ArgumentException("Component name cannot be null or empty.", nameof(componentName));
            }

            var descriptor = new ComponentRendererDescriptor(
                match,
                sp => ActivatorUtilities.CreateInstance<ModelBoundComponentRenderer<TModel>>(sp, componentName)
            );

            options.RendererRegistry.Add(options.RendererRegistry.Count, descriptor);
            return options;
        }
    }
}
