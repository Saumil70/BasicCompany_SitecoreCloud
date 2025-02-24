using BasicCompany.Feature.Navigation.Services;
using Sitecore.LayoutService.Configuration;
using Sitecore.Mvc.Presentation;
using System.Diagnostics;
using System.Linq;

namespace BasicCompany.Feature.Navigation.LayoutService
{
    public class HeaderContentsResolver : Sitecore.LayoutService.ItemRendering.ContentsResolvers.RenderingContentsResolver
    {
        protected readonly IHeaderBuilder HeaderBuilder;
        private readonly SiteSettings _siteSettings;


        public HeaderContentsResolver(INavigationRootResolver rootResolver, IHeaderBuilder headerBuilder, SiteSettings siteSettings)
        {
            Debug.Assert(rootResolver != null);
            Debug.Assert(headerBuilder != null);
            HeaderBuilder = headerBuilder;
            _siteSettings = siteSettings;
        }

        public override object ResolveContents(Rendering rendering, IRenderingConfiguration renderingConfig)
        {
            var header = HeaderBuilder.GetHeader(this.GetContextItem(rendering, renderingConfig));
            var contents = new
            {
                logoLink = this.ProcessItem(header.HomeItem, rendering, renderingConfig),
                navItems = header.NavigationItems.Select(x => new
                {
                    url = x.Url,
                    isActive = x.IsActive,
                    title = x.Item[Templates.NavigationItem.Fields.NavigationTitle]
                }),
                supportedLanguages = _siteSettings.SupportedLanguages()
            };
            return contents;
        }
    }
}