using Sitecore.AspNetCore.SDK.LayoutService.Client.Response.Model.Fields;

namespace BasicCompany.Blazor.Models.Navigation
{
    public class LogoLink
    {
        public TextField NavigationTitle { get; set; }

        public ImageField HeaderLogo { get; set; }
    }
}
