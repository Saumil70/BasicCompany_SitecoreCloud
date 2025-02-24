using Sitecore.AspNetCore.SDK.RenderingEngine.Binding.Attributes;
using Sitecore.AspNetCore.SDK.LayoutService.Client.Response.Model.Fields;

namespace BasicCompany.Blazor.Models.Services
{
    public class AccordionItem
    {
        public TextField Title { get; set; }

        public RichTextField Content { get; set; }

        [SitecoreContextProperty]
        public bool IsEditing { get; set; }
    }
}
