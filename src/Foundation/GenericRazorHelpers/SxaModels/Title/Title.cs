using GenericRazorHelpers.SxaModels.Generic;
using Newtonsoft.Json;

namespace GenericRazorHelpers.SxaModels.Title;

public class Title : BaseModel
{
    [JsonProperty("data")]
    public TitleData? Data { get; set; }

    public HyperLinkField Link
    {
        get
        {
            var hyperLink = new HyperLink
            {
                Anchor = TitleLocation?.Url?.Path,
                Title = TitleLocation?.Field?.JsonValue?.Value
            };
            return new HyperLinkField(hyperLink)
            {
                Value = hyperLink
            };
        }
    }

    public TextField Text
    {
        get
        {
            var textField = TitleLocation?.Field?.JsonValue;
            return new TextField
            {
                Value = textField?.Value
            };
        }
    }

    public TitleLocation? TitleLocation
    {
        get
        {
            return Data?.DataSource ?? Data?.ContextItem;
        }
    }
}