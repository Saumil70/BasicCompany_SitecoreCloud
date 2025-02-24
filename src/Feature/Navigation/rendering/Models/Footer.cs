using Sitecore.AspNet.RenderingEngine.Binding.Attributes;

namespace BasicCompany.Feature.Navigation.Models
{
    public class Footer
    {
        [SitecoreComponentField]
        public string FooterText { get; set; }
    }
}
