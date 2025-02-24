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