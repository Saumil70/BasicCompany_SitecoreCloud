using BasicCompany.Blazor.Models.Products;
using BasicCompany.Feature.Products.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BasicCompany.Feature.Products.Controllers
{
    public class SearchController : Controller
    {
        private readonly IProductSearchService _productSearchService;

        public SearchController(IProductSearchService productSearchService)
        {
            _productSearchService = productSearchService;
        }

        public ActionResult SearchProducts(string searchText, string templateId)
        {
            try
            {
                List<ProductSearchQuery> products = _productSearchService.SearchProducts(searchText, templateId);
                List<ProductResponse> productResponses = products.Select(p => new ProductResponse
                {
                    UniqueId = p.UniqueId.ToString(),
                    Paths = p.Paths.Select(id => id.ToString()).ToList(),
                    Templates = p.Templates.Select(id => id.ToString()).ToList(),
                    Title = p.Title,
                    ShortDescription = p.ShortDescription,
                    ImageUrl = p.ImageUrl,
                    ItemUrl = p.ItemUrl
                }).ToList();

                JsonSerializerSettings jsonSettings = new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                };
                string jsonResult = JsonConvert.SerializeObject(productResponses, jsonSettings);
                return Content(jsonResult, "application/json");
            }
            catch (Exception ex)
            {
                var errorResult = new { error = ex.Message };
                string errorJson = JsonConvert.SerializeObject(errorResult);
                return Content(errorJson, "application/json");
            }
        }
    }
}
