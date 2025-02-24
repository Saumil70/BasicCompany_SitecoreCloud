using System.Web;

namespace GenericRazorHelpers.SxaModels.Generic
{
    public class RichTextField : EditableField<string>
    {

        public RichTextField()
        {
            Value = string.Empty;
        }

        public RichTextField(string value, bool encoded = true)
        {
            if (value == null)
            {
                value = string.Empty;
            }

            Value = Build(value, encoded);
        }

        private static string Build(string value, bool encoded)
        {
            if (!encoded)
            {
                return value;
            }

            return HttpUtility.UrlDecode(value);
        }
    }
}
