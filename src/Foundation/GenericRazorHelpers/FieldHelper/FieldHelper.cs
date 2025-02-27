using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Sitecore.AspNetCore.SDK.LayoutService.Client.Response.Model;
using System.Reflection;

namespace GenericRazorHelpers.FieldHelper
{
    public static class FieldHelper
    {
        public static T MapModel<T>(Component component)
        {
            Dictionary<string, object>? dictionaryFields = new Dictionary<string, object>();

            if (component.Parameters.Count != 0)
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
                        .GetField("_json", BindingFlags.NonPublic | BindingFlags.Instance)?
                        .GetValue(field.Value) as string;

                    JToken fieldValueJToken = null;

                    if (fieldValue != null)
                    {
                        fieldValueJToken = JToken.Parse(fieldValue);
                    }

                    dictionaryFields[field.Key] = fieldValueJToken;
                }
            }
            return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(dictionaryFields));
        }
    }

}
