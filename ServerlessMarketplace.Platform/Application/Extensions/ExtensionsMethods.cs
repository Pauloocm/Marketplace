namespace ServerlessMarketplace.Platform.Application.Extensions
{
    public static class ExtensionsMethods
    {
        public static bool IsValidEmail(this string value)
        {
            if (string.IsNullOrEmpty(value)) return false;

            if (value.Length < 5) return false;

            if (value.ElementAt(0) == '@' || value.ElementAt(value.Length - 1) == '@')
                return false;

            return value.Contains('@');
        }
    }
}