using Newtonsoft.Json;

namespace GenericRazorHelpers.SxaModels.LinkList;

public class DatasourceField
{
    [JsonProperty("field")]
    public LinkListField? Field { get; set; }

    [JsonProperty("children")]
    public LinkListChildren? Children { get; set; }
}