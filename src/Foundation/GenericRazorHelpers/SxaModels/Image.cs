using GenericRazorHelpers.SxaModels.Generic;
using Newtonsoft.Json;
using Sitecore.AspNetCore.SDK.RenderingEngine.Binding.Attributes;

namespace GenericRazorHelpers.SxaModels
{
    public class Image : BaseModel
    {
        public const string VARIANT_BANNER = "Banner";
        public HyperLinkField? TargetUrl { get; set; }

        [JsonProperty("Image")]
        public ImageField? ImageField { get; set; }
        public TextField? ImageCaption { get; set; }
    }
}
