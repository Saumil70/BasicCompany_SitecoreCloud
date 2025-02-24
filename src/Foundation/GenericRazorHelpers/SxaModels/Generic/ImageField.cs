
namespace GenericRazorHelpers.SxaModels.Generic
{
    public class ImageField : EditableField<Sitecore.LayoutService.Client.Response.Model.Properties.Image>
    {
        public ImageField()
        {
        }
        public ImageField(Sitecore.LayoutService.Client.Response.Model.Properties.Image value)
        {
            base.Value = value;
        }
    }
}
