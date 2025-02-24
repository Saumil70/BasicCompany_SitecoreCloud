using GenericRazorHelpers.SxaModels.Generic;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace GenericRazorHelpers.SxaModels.LinkList;

public class LinkListField
{
    [JsonProperty("title")]
    public TextField? Title { get; set; }
}