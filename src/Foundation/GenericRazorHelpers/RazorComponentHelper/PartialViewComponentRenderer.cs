using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Sitecore.AspNetCore.SDK.RenderingEngine.Interfaces;
using Sitecore.AspNetCore.SDK.RenderingEngine.Rendering;

namespace GenericRazorHelpers.RazorComponentHelper
{
    public class PartialViewComponentRenderer : IComponentRenderer
    {
        private readonly string _componentName;
        public static ComponentRendererDescriptor Describe(Predicate<string> match, string componentName)
        {
            return new ComponentRendererDescriptor(match, (sp) => ActivatorUtilities.CreateInstance<PartialViewComponentRenderer>(sp, new object[1] { componentName }));
        }

        public PartialViewComponentRenderer(string componentName)
        {
            if (string.IsNullOrWhiteSpace(componentName))
            {
                throw new ArgumentException("Component name cannot be null or empty", nameof(componentName));
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

            return await htmlHelper.RenderComponentAsync(componentType, RenderMode.Static, null);
        }
        private Type GetType(string parameter)
        {
            // Convert the input to PascalCase
            var pascalCaseParameter = ConvertToPascalCase(parameter);

            // Iterate through all assemblies loaded in the current AppDomain
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                // Search for the type in the assembly
                var type = assembly.GetTypes().FirstOrDefault(t => t.Name == pascalCaseParameter);
                if (type != null)
                {
                    return type; // Return the type if found
                }
            }

            // If not found, return null
            return null;
        }


        public static string ConvertToPascalCase(string input)
        {
            var words = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            for (var i = 0; i < words.Length; i++)
            {
                if (words[i].Length > 0)
                {
                    words[i] = char.ToUpper(words[i][0]) + words[i].Substring(1);
                }
            }

            return string.Join(string.Empty, words);
        }
    }
}