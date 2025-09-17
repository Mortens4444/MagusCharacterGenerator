using Mtf.LanguageService;
using System.Globalization;

namespace M.A.G.U.S.Assistant.Converters
{
    public class TranslationConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is string key)
            {
                return Lng.Elem(key);
            }
            return value;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
