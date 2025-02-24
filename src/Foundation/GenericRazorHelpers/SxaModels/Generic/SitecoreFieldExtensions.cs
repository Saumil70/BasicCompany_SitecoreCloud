using Microsoft.AspNetCore.WebUtilities;
using System.Text.RegularExpressions;

namespace GenericRazorHelpers.SxaModels.Generic
{
    public static class SitecoreFieldExtensions
    {
        private static readonly Regex _mediaUrlPrefixRegex = new Regex("/([-~]{1})/media/");

        public static string? GetMediaLink(this ImageField imageField, object imageParams)
        {
            string src = imageField.Value.Src;
            if (src == null)
            {
                return null;
            }

            return GetSitecoreMediaUri(src, imageParams);
        }

        private static string GetSitecoreMediaUri(string url, object imageParams)
        {
            if (imageParams != null)
            {
                string[] array = url.Split('?');
                if (array.Length > 1)
                {
                    url = array[0];
                }

                RouteValueDictionary routeValueDictionary = new RouteValueDictionary(imageParams);
                foreach (string key in routeValueDictionary.Keys)
                {
                    url = QueryHelpers.AddQueryString(url, key, routeValueDictionary[key].ToString());
                }
            }

            Match match = _mediaUrlPrefixRegex.Match(url);
            if (match.Success)
            {
                url = url.Replace(match.Value, $"/{match.Groups[1]}/jssmedia/", StringComparison.InvariantCulture);
            }

            return url;
        }
    }
}
