using Sitecore.Abstractions;
using Sitecore.ContentSearch;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Resources.Media;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace BasicCompany.Feature.Products.Services
{
    public class ProductSearchService : IProductSearchService
    {
        protected readonly BaseFactory Factory;
        protected readonly BaseItemManager ItemManager;
        protected readonly BaseLinkManager LinkManager;
        protected readonly BaseMediaManager MediaManager;

        public ProductSearchService(BaseFactory factory, BaseItemManager itemManager, BaseLinkManager linkManager, BaseMediaManager mediaManager)
        {
            Debug.Assert(factory != null);
            Debug.Assert(itemManager != null);
            Debug.Assert(linkManager != null);
            Debug.Assert(mediaManager != null);
            Factory = factory;
            ItemManager = itemManager;
            LinkManager = linkManager;
            MediaManager = mediaManager;
        }

        public List<ProductSearchQuery> SearchProducts(string searchText, string templateId)
        {
            using (IProviderSearchContext context = ContentSearchManager.GetIndex("sitecore_web_index").CreateSearchContext())
            {
                ID templateGuid = new ID(templateId);
                List<ProductSearchQuery> results = new List<ProductSearchQuery>();
                if (string.IsNullOrEmpty(searchText))
                {
                    results = context.GetQueryable<ProductSearchQuery>()
                        .Where(product => product.Templates.Contains(templateGuid) && product.Name != "__Standard Values")
                        .ToList();
                }
                else
                {
                    results = context.GetQueryable<ProductSearchQuery>()
                        .Where(product => product.Templates.Contains(templateGuid) &&
                                          (product.Title.Contains(searchText) || product.ShortDescription.Contains(searchText) || product.Name.Contains(searchText)) && product.Name != "__Standard Values")
                        .ToList();
                }

                foreach (ProductSearchQuery result in results)
                {
                    Item item = ItemManager.GetItem(result.UniqueId.ItemID, result.UniqueId.Language, result.UniqueId.Version, Factory.GetDatabase(result.UniqueId.DatabaseName));
                    result.ItemUrl = LinkManager.GetItemUrl(item);
                    ImageField imageField = (ImageField)item.Fields["Image"];
                    if (imageField?.MediaItem != null)
                    {
                        MediaUrlOptions mediaUrlOptions = new MediaUrlOptions
                        {
                            AlwaysIncludeServerUrl = true,
                            MaxWidth = 480,
                            AllowStretch = false
                        };
                        result.ImageUrl = MediaManager.GetMediaUrl(imageField.MediaItem, mediaUrlOptions).Replace("/-/media", "/-/jssmedia");
                    }
                }

                return results;
            }
        }
    }
}
