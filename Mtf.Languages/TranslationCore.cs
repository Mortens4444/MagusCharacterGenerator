using Mtf.Languages.Utils;
using System.Globalization;

namespace Mtf.Languages
{
	public static class TranslationCore
	{
		public static Language Language;

        static TranslationCore()
        {
            ChangeToLanguage(CultureInfo.CurrentCulture);
        }

		public static void ChangeToLanguage(CultureInfo cultureInfo)
        {
            var cultureInfoToLanguageConverter = new CultureInfoToLanguageConverter();
            ChangeToLanguage(cultureInfoToLanguageConverter.Convert(cultureInfo));
        }

        public static void ChangeToLanguage(Language language)
        {
            Language = language;
        }
    }
}
