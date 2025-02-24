using BasicCompany.Feature.Navigation.Helper;
using Sitecore.AspNet.RenderingEngine.Binding.Attributes;
using System.Collections.Generic;

namespace BasicCompany.Feature.Navigation.Models
{
    public class Header
    {
        /// <summary>
        /// Our bound property does not inherit from Field, so we need to bind it explicitly.
        /// </summary>
        [SitecoreComponentField]
        public NavigationItem[] NavItems { get; set; }

        [SitecoreComponentField]
        public LogoLink LogoLink { get; set; }

        public string ImageUrl
        {
            get
            {
                return ImageHelper.TransformImageUrl(LogoLink?.HeaderLogo?.Value?.Src);
            }
        }

        [SitecoreComponentField]
        public IEnumerable<SupportedLanguage> SupportedLanguages { get; set; }
    }
}
