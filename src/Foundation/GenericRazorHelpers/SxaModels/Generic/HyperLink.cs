using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace GenericRazorHelpers.SxaModels.Generic
{
    public class HyperLink
    {
        public string? Href { get; set; }

        [DataMember(EmitDefaultValue = false)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string? Text { get; set; }

        [DataMember(EmitDefaultValue = false)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string? Target { get; set; }

        [DataMember(EmitDefaultValue = false)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string? Class { get; set; }

        [DataMember(EmitDefaultValue = false)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string? Title { get; set; }

        [DataMember(EmitDefaultValue = false)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string? Anchor { get; set; }
    }
}
