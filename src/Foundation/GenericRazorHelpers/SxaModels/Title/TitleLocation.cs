using System.Text.Json.Serialization;

namespace GenericRazorHelpers.SxaModels.Title;

public class TitleLocation
{
    public TitleUrl? Url { get; set; }
    public TitleField? Field { get; set; }
}