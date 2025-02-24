using Sitecore.AspNet.RenderingEngine.Binding.Attributes;

namespace BasicCompany.Blazor.Models.Navigation
{
    public class Footer
    {
        [SitecoreComponentField]
        public string FooterText { get; set; }
    }
}
