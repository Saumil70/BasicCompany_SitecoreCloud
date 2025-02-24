using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace GenericRazorHelpers.SxaModels.LinkList;

public class LinkListChildren
{
    [JsonProperty("results")]
    public List<LinkListItem>? Results { get; set; }
}