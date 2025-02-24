using Sitecore.AspNet.RenderingEngine.Binding.Attributes;
using Sitecore.AspNet.RenderingEngine.Binding;

namespace GenericRazorHelpers.SxaModels.Generic
{
    public class BaseModel
    {
        public bool IsEditing { get; set; }
        public string? Id { get; set; }
        public string? ComponentName { get; set; }
        public string? GridParameters { get; set; }
        public string? FieldNames { get; set; }
        public string? Styles { get; set; }
        public int DynamicPlaceholderId { get; set; } = 1;
    }
}
