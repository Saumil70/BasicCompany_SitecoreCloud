using Sitecore.Data.Items;
using System.Collections.Generic;

namespace BasicCompany.Feature.Products.Services
{
    public interface IProductRepository
    {
        IEnumerable<Item> GetProducts(Item parent);
    }
}
