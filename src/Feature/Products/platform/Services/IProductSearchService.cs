using System.Collections.Generic;

namespace BasicCompany.Feature.Products.Services
{
    public interface IProductSearchService
    {
        List<ProductSearchQuery> SearchProducts(string searchText, string templateId);
    }
}
