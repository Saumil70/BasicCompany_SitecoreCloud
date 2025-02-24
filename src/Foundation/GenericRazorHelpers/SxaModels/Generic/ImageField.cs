
namespace GenericRazorHelpers.SxaModels.Generic
{
    public class ImageField : EditableField<Sitecore.AspNetCore.SDK.LayoutService.Client.Response.Model.Properties.Image>
    {
        public ImageField()
        {
        }
        public ImageField(Sitecore.AspNetCore.SDK.LayoutService.Client.Response.Model.Properties.Image value)
        {
            base.Value = value;
        }
    }
}
