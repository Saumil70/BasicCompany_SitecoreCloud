using Newtonsoft.Json;

namespace GenericRazorHelpers.SxaModels.LinkList;

public class LinkListItem
{
    [JsonProperty("field")]
    public LinkListItemField? Field { get; set; }
}