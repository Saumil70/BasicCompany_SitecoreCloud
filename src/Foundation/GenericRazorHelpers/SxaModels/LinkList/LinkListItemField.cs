using GenericRazorHelpers.SxaModels.Generic;
using Newtonsoft.Json;

namespace GenericRazorHelpers.SxaModels.LinkList;

public class LinkListItemField
{
    [JsonProperty("link")]
    public HyperLinkField? Link { get; set; }
}