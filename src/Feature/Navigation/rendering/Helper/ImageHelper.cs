namespace BasicCompany.Feature.Navigation.Helper
{
    public static class ImageHelper
    {
        public static string TransformImageUrl(string src)
        {
            if (src != null)
            {
                if (src.Contains("/-/media/"))
                {
                    return src.Replace("/-/media/", "/-/jssmedia/");
                }
                return src;
            }
            return src;
        }
    }
}
