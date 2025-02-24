using Sitecore.AspNetCore.SDK.LayoutService.Client.Response.Model.Fields;

namespace BasicCompany.Blazor.Models.Services
{
    public class Testimonial
    {
        public TextField Title { get; set; }

        public RichTextField Quote { get; set; }

        public ImageField Image { get; set; }
    }
}
