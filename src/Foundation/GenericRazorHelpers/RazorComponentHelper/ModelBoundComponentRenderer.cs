using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Sitecore.AspNet.RenderingEngine;
using Sitecore.AspNet.RenderingEngine.Rendering;

namespace GenericRazorHelpers.RazorComponentHelper
{
    public class ModelBoundComponentRenderer<TModel> : IComponentRenderer
    {
        private readonly string _componentName;

        public ModelBoundComponentRenderer(string componentName)
        {
            if (string.IsNullOrEmpty(componentName))
            {
                throw new ArgumentException("Component name cannot be null or empty.", nameof(componentName));
            }

            _componentName = componentName;
        }

        public async Task<IHtmlContent> Render(ISitecoreRenderingContext renderingContext, ViewContext viewContext)
        {
            if (renderingContext == null)
            {
                throw new ArgumentNullException(nameof(renderingContext));
            }

            if (viewContext == null)
            {
                throw new ArgumentNullException(nameof(viewContext));
            }

            var htmlHelper = viewContext.HttpContext.RequestServices.GetRequiredService<IHtmlHelper>();

            if (htmlHelper is IViewContextAware viewContextAware)
            {
                viewContextAware.Contextualize(viewContext);
            }
            else
            {
                throw new InvalidOperationException("The IHtmlHelper does not support contextualization.");
            }

            var componentType = GetType(_componentName);
            if (componentType == null)
            {
                throw new ArgumentException($"Component type '{_componentName}' cannot be found.", nameof(_componentName));
            }

            var fields = renderingContext.Component.Fields;

            return await htmlHelper.RenderComponentAsync(componentType, RenderMode.Static, new { Fields = fields });
        }

        private Type? GetType(string parameter)
        {
            if (string.IsNullOrEmpty(parameter))
            {
                throw new ArgumentException("Parameter cannot be null or empty.", nameof(parameter));
            }

            var pascalCaseParameter = ConvertToPascalCase(parameter);

            // Iterate through all loaded assemblies in the current AppDomain
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                var type = assembly.GetTypes()
                                   .FirstOrDefault(t => t.Name.Equals(pascalCaseParameter, StringComparison.OrdinalIgnoreCase));
                if (type != null)
                {
                    return type;
                }
            }

            return null;
        }

        public static string ConvertToPascalCase(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException("Input cannot be null or empty.", nameof(input));
            }

            var words = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (var i = 0; i < words.Length; i++)
            {
                if (words[i].Length > 0)
                {
                    words[i] = char.ToUpper(words[i][0]) + words[i][1..];
                }
            }

            return string.Join(string.Empty, words);
        }
    }
}
