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
            return new HyperLinkField(
                    new HyperLink
                    {
                        Anchor = TitleLocation?.Url?.Path,
                        Title = TitleLocation?.Field?.JsonValue?.Value
                    });
        }
    }

    public TextField Text
    {
        get
        {
            TextField textField = new TextField();
            textField = TitleLocation?.Field?.JsonValue;
            return textField;
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