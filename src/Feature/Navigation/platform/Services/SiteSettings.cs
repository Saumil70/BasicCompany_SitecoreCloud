using Sitecore.Data.Managers;
using Sitecore.Globalization;
using System.Collections.Generic;

namespace BasicCompany.Feature.Navigation.Services
{
    public class SiteSettings
    {
        public List<dynamic> SupportedLanguages()
        {
            var languages = LanguageManager.GetLanguages(Sitecore.Context.Database);

            // Create a list to hold the detailed language information
            var languageList = new List<dynamic>();

            foreach (var language in languages)
            {
                var languageCode = language.Name;
                var nativeName = GetNativeName(language); // Implement a method to fetch native name
                var twoLetterCode = GetTwoLetterCode(language); // Implement a method to fetch the two-letter code
                var url = $"/{languageCode.ToLowerInvariant()}/"; // Generate URL dynamically

                languageList.Add(new
                {
                    name = languageCode,
                    nativeName = nativeName,
                    url = url,
                    twoLetterCode = twoLetterCode,
                    isSelected = Sitecore.Context.Language.Name == languageCode
                });
            }

            return languageList;
        }

        private string GetNativeName(Language language)
        {
            // For simplicity, return language's display name
            return language.CultureInfo.NativeName;
        }

        private string GetTwoLetterCode(Language language)
        {
            // Return the ISO two-letter code, if available
            return language.CultureInfo.TwoLetterISOLanguageName;
        }
    }
}
