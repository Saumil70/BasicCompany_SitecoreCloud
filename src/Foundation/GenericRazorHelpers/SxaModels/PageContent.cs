using GenericRazorHelpers.SxaModels.Generic;
using Newtonsoft.Json;

namespace GenericRazorHelpers.SxaModels;

public class PageContent : BaseModel
{
    public RichTextField? Text { get; set; }
}
