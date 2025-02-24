using GenericRazorHelpers.Localizer;
using Microsoft.AspNetCore.Mvc;

namespace BasicCompany.Blazor.Controllers
{
    public class LocalizationController : Controller
    {
        private readonly ISitecoreLocalizer _sitecoreLocalizer;

        public LocalizationController(ISitecoreLocalizer sitecoreLocalizer)
        {
            _sitecoreLocalizer = sitecoreLocalizer;
        }

        [HttpPost]
        public IActionResult Reload()
        {
            _sitecoreLocalizer.Reload();
            return Ok();
        }
    }
}
