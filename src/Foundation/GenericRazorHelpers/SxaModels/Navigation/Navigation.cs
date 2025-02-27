using GenericRazorHelpers.SxaModels.Generic;
using Sitecore.AspNetCore.SDK.LayoutService.Client.Serialization.Converter;
using Sitecore.AspNetCore.SDK.RenderingEngine.Binding.Attributes;

namespace GenericRazorHelpers.SxaModels.Navigation;

public class Navigation : BaseModel
{
    public Navigation(List<NavigationItem>? navigationItems, int? menuLevel)
    {
        CustomContent = navigationItems;
        MenuLevel = menuLevel;
    }

    public List<NavigationItem>? CustomContent { get; set; }

    public int? MenuLevel { get; set; }
}