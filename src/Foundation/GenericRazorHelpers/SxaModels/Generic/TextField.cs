namespace GenericRazorHelpers.SxaModels.Generic
{
    public class TextField : EditableField<string>
    {
        public TextField()
        {
        }

        public TextField(string value)
        {
            base.Value = value;
        }
    }
}
