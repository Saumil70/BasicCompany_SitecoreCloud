using Sitecore.LayoutService.Client.Response.Model.Fields;

namespace BasicCompany.Blazor.Models.BasicContent
{
    public class FrontProduct
    {
        public HyperLinkField Link { get; set; }
        public ImageField Image { get; set; }
        public TextField Headline { get; set; }
        public RichTextField Text { get; set; }
    }
}
