using BasicCompany.Feature.Products.Controllers;
using Microsoft.Extensions.DependencyInjection;
using Sitecore.DependencyInjection;

namespace BasicCompany.Feature.Products
{
    public class ServicesConfigurator : IServicesConfigurator
    {
        public void Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<SearchController>();
            serviceCollection.AddTransient<Services.IProductRepository, Services.ProductRepository>();
            serviceCollection.AddTransient<Services.IProductSearchService, Services.ProductSearchService>();
        }
    }
}