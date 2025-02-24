namespace BasicCompany.Blazor.Configuration
{
    /// <summary>
    /// Example of a custom bound configuration object. Used in the Startup class to bind configuration options
    /// and configure the Sitecore ASP.NET SDK services.
    /// </summary>
    public class SitecoreOptions
    {
        public static readonly string Key = "Sitecore";

        public Uri InstanceUri { get; set; }
        public string LayoutServicePath { get; set; } = "/sitecore/api/layout/render/jss";
        public string DictionaryServicePath { get; set; } = "/sitecore/api/jss/dictionary";
        public string SearchServicePath { get; set; } = "/api/sitecore/Search";
        public string DefaultSiteName { get; set; }
        public string ApiKey { get; set; }
        public Uri RenderingHostUri { get; set; }
        public string JssEditingSecret { get; set; }
        public bool EnableExperienceEditor { get; set; }

        public Uri LayoutServiceUri
        {
            get
            {
                if (InstanceUri == null) return null;

                return new Uri(InstanceUri, LayoutServicePath);
            }
        }

        public string ProductTemplateId { get; set; }
        public Uri SearchUrl
        {
            get
            {
                if (InstanceUri == null) return null;
                return new Uri(InstanceUri, SearchServicePath);
            }
        }
        public string FullDictionaryUrl => InstanceUri == null || string.IsNullOrEmpty(ApiKey) || string.IsNullOrEmpty(DefaultSiteName) ? null : $"{InstanceUri}{DictionaryServicePath}/{DefaultSiteName}/en?sc_apikey={ApiKey}";

        public Uri DictionaryServiceUri => InstanceUri == null ? null : new Uri(InstanceUri, FullDictionaryUrl);

    }
}
