using Newtonsoft.Json;
using Sitecore.AspNetCore.SDK.LayoutService.Client.Response.Model;
using System.Runtime.Serialization;

namespace GenericRazorHelpers.SxaModels.Generic
{
    public class WrappedEditableField<TValue> : Field<TValue>, IWrappedEditableField, IField
    {
        [DataMember(Name = "editableFirstPart")]
        [JsonProperty("editableFirstPart")]
        public string EditableMarkupFirst { get; set; } = string.Empty;

        [DataMember(Name = "editableLastPart")]
        [JsonProperty("editableLastPart")]
        public string EditableMarkupLast { get; set; } = string.Empty;

    }
}
