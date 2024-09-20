namespace DigiBite_Core.Helpers
{
    public static class LanguageService
    {
        public static string Lang { get; set; }

        public static string SelectLang(string ArabicText, string EnglishText)
        => Lang is "en" ? EnglishText : ArabicText;

    }
}
