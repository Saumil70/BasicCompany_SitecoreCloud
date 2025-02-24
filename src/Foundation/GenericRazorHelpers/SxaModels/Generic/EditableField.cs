using Newtonsoft.Json;
using Sitecore.LayoutService.Client.Response.Model;
using System.Runtime.Serialization;


namespace GenericRazorHelpers.SxaModels.Generic
{
    public class EditableField<TValue> : Field<TValue>, IEditableField, IField
    {
        [DataMember(Name = "editable")]
        [JsonProperty("editable")]
        public string EditableMarkup { get; set; } = string.Empty;
    }
}
