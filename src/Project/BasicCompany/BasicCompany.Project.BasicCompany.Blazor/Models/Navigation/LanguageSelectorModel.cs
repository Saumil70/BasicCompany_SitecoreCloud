using Sitecore.AspNet.RenderingEngine.Binding.Attributes;

namespace BasicCompany.Blazor.Models.Navigation
{
    public class LanguageSelectorModel
    {
        [SitecoreComponentField]
        public SupportedLanguage[] SupportedLanguages { get; set; }
    }

    public class SupportedLanguage
    {
        public string Name { get; set; }
        public string NativeName { get; set; }
        public string Url { get; set; }
        public string TwoLetterCode { get; set; }
        public bool IsSelected { get; set; }
    }
}
