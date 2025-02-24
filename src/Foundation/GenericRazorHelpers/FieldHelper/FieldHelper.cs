using Newtonsoft.Json;
using Sitecore.AspNetCore.SDK.LayoutService.Client.Response.Model;

namespace GenericRazorHelpers.FieldHelper
{
    public static class FieldHelper
    {
        public static T MapModel<T>(Component component)
        {
            Dictionary<string, object>? dictionaryFields = new Dictionary<string, object>();

            if (component.Parameters.Count != 0 )
            {
                foreach (KeyValuePair<string, string> parameter in component.Parameters)
                {
                    dictionaryFields[parameter.Key] = parameter.Value;
                }
            }

            if (component.Fields.Count != 0)
            {
                foreach (KeyValuePair<string, IFieldReader> field in component.Fields)
                {
                    var fieldValue = field.Value?.GetType()
                        .GetField("_json", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)?
                        .GetValue(field.Value);

                    dictionaryFields[field.Key] = fieldValue;
                }
            }
            return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(dictionaryFields));
        }
    }

}
