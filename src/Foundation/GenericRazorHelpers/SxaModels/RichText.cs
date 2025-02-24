using GenericRazorHelpers.SxaModels.Generic;
using Sitecore.AspNet.RenderingEngine.Binding.Attributes;
namespace GenericRazorHelpers.SxaModels
{
    public class RichText : BaseModel
    {
        public RichTextField? Text { get; set; }
    }
}
