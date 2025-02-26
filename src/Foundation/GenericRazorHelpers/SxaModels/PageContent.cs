using GenericRazorHelpers.SxaModels.Generic;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;

namespace GenericRazorHelpers.SxaModels;

public class PageContent : BaseModel
{
    public RichTextField? RouteContent { get; set; }

    public RichTextField? Text { get; set; }

    public RichTextField? Content
    {
        get
        {
            return Text ?? RouteContent;
        }
    }
}
