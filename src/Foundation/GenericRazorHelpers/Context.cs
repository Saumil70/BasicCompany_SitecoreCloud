using Sitecore.AspNetCore.SDK.LayoutService.Client.Response.Model;

namespace GenericRazorHelpers
{
    public class Context
    {
        public string? DatabaseName { get; set; }
        public string? DeviceId { get; set; }
        public string? ItemId { get; set; }
        public string? ItemLanguage { get; set; }
        public int? ItemVersion { get; set; }
        public string? LayoutId { get; set; }
        public string? TemplateId { get; set; }
        public string? TemplateName { get; set; }
        public string? Name { get; set; }
        public Dictionary<string, IFieldReader> Fields { get; set; } = new Dictionary<string, IFieldReader>(StringComparer.OrdinalIgnoreCase);
    }
}
