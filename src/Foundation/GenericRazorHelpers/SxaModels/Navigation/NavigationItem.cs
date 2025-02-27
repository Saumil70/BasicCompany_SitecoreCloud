
using GenericRazorHelpers.SxaModels.Generic;

namespace GenericRazorHelpers.SxaModels.Navigation
{
    public class NavigationItem
    {
        public string? Id { get; set; }

        public List<string>? Styles { get; set; } = [];

        public List<NavigationItem>? Children { get; set; } = [];

        public string? Href { get; set; }

        public string? QueryString { get; set; }

        public TextField? NavigationTitle { get; set; }
    }
}