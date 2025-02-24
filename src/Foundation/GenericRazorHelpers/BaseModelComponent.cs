using Microsoft.AspNetCore.Components;
using Sitecore.LayoutService.Client.Response.Model;

namespace GenericRazorHelpers
{
    public abstract class BaseModelComponent<TModel> : ComponentBase
    {
        [Parameter]
        public Component Component { get; set; }

        public TModel Model { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                Model = FieldHelper.FieldHelper.MapModel<TModel>(Component);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during deserialization: {ex.Message}");
            }
        }
    }
}
