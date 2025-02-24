using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace GenericRazorHelpers.SxaModels.LinkList;

public class DataField
{
    [JsonProperty("datasource")]
    public DatasourceField? Datasource { get; set; }
}