using GenericRazorHelpers.SxaModels.Generic;
using Newtonsoft.Json;

namespace GenericRazorHelpers.SxaModels.LinkList;

public class LinkList : BaseModel
{
    [JsonProperty("data")]
    public DataField? Data { get; set; }

    public TextField? Title
    {
        get
        {
            return Data?.Datasource?.Field?.Title;
        }
    }

    public List<LinkListItem> Children
    {
        get
        {
            return Data?.Datasource?.Children?.Results ?? new List<LinkListItem>();
        }
    }
}