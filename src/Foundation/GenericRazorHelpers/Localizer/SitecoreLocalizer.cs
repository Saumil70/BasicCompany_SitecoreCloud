using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Globalization;

namespace GenericRazorHelpers.Localizer
{
    public interface ISitecoreLocalizer : IStringLocalizer
    {
        Task Reload();
    }

    public class SitecoreLocalizer : ISitecoreLocalizer
    {
        private static readonly Dictionary<string, Dictionary<string, string>> _sitecoreDictionary = new();
        private readonly HttpClient _httpClient;
        private readonly SitecoreLocalizerOptions _sitecoreLocalizerOptions;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SitecoreLocalizer(
            IHttpClientFactory httpClientFactory,
            IOptions<SitecoreLocalizerOptions> sitecoreLocalizerOptions,
            IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClientFactory.CreateClient("sitecoreLocalizer");
            _sitecoreLocalizerOptions = sitecoreLocalizerOptions?.Value;
            _httpContextAccessor = httpContextAccessor;
        }

        public LocalizedString this[string name]
        {
            get
            {
                var culture = _httpContextAccessor.HttpContext?.Features.Get<IRequestCultureFeature>()?.RequestCulture.Culture.ToString();
                if (culture != null && _sitecoreDictionary.TryGetValue(culture, out var cultureDictionary) && cultureDictionary.TryGetValue(name, out var value))
                {
                    return new LocalizedString(name, value);
                }
                return new LocalizedString(name, name);
            }
        }

        public LocalizedString this[string name, params object[] arguments]
        {
            get
            {
                var culture = _httpContextAccessor.HttpContext?.Features.Get<IRequestCultureFeature>()?.RequestCulture.Culture.ToString();
                if (culture != null && _sitecoreDictionary.TryGetValue(culture, out var cultureDictionary) && cultureDictionary.TryGetValue(name, out var value))
                {
                    return new LocalizedString(name, string.Format(value, arguments));
                }
                return new LocalizedString(name, name);
            }
        }

        public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
        {
            var culture = _httpContextAccessor.HttpContext?.Features.Get<IRequestCultureFeature>()?.RequestCulture.Culture.ToString();
            if (culture != null && _sitecoreDictionary.TryGetValue(culture, out var cultureDictionary))
            {
                foreach (var dictionaryItem in cultureDictionary)
                {
                    yield return new LocalizedString(dictionaryItem.Key, dictionaryItem.Value);
                }
            }
        }

        public async Task Reload()
        {
            foreach (var culture in _sitecoreLocalizerOptions.Cultures)
            {
                var response = await _httpClient.GetAsync(_httpClient.BaseAddress.AbsoluteUri.Replace("[language]", culture.ToString())).ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    _sitecoreDictionary[culture.ToString()] = JsonConvert.DeserializeObject<DictionaryModel>(content).Phrases;
                }
            }
        }

        public IStringLocalizer WithCulture(CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class DictionaryModel
    {
        public Dictionary<string, string> Phrases { get; set; }
    }

    public class SitecoreLocalizerOptions
    {
        public IEnumerable<CultureInfo> Cultures { get; set; }
    }
}
