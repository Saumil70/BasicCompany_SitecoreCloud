using BasicCompany.Blazor.Models;
using GenericRazorHelpers.Service;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Sitecore.AspNetCore.SDK.LayoutService.Client.Exceptions;
using Sitecore.AspNetCore.SDK.RenderingEngine.Attributes;
using System.Net;

namespace BasicCompany.Blazor.Controllers
{
    public class DefaultController : Controller
    {

        public DefaultController()
        {

        }

        // Inject Sitecore rendering middleware for this controller action
        // (enables model binding to Sitecore objects such as Route,
        // and causes requests to the Sitecore Layout Service for controller actions)
        [UseSitecoreRendering]
        public IActionResult Index(Sitecore.AspNetCore.SDK.LayoutService.Client.Response.Model.Route route, [FromServices] RouteService routeService)
        {
            var request = HttpContext.GetSitecoreRenderingContext();
            IActionResult result = Empty;

            if (request.Response.HasErrors)
            {
                foreach (var error in request.Response.Errors)
                {
                    switch (error)
                    {
                        case ItemNotFoundSitecoreLayoutServiceClientException:
                            result = View("NotFound");
                            break;
                        case InvalidRequestSitecoreLayoutServiceClientException badRequest:
                        case CouldNotContactSitecoreLayoutServiceClientException transportError:
                        case InvalidResponseSitecoreLayoutServiceClientException serverError:
                        default:
                            throw error;
                    }
                }
            }
            routeService.SetRoute(route);

            return View(route);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            var exceptionHandlerPathFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            return View(new ErrorViewModel
            {
                IsInvalidRequest = exceptionHandlerPathFeature?.Error is InvalidRequestSitecoreLayoutServiceClientException
            });
        }
    }
}
