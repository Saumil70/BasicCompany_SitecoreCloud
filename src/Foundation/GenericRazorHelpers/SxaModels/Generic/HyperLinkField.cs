using Sitecore.LayoutService.Client.Response.Model.Properties;
using Sitecore.LayoutService.Client.Response.Model;

namespace GenericRazorHelpers.SxaModels.Generic
{
    public class HyperLinkField : WrappedEditableField<HyperLink>
    {
        public HyperLinkField()
        {
        }

        public HyperLinkField(HyperLink value)
        {
            base.Value = value;
        }
    }
}