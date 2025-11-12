using Mtf.LanguageService;
using System.Globalization;

namespace M.A.G.U.S.Assistant.Converters;

internal class TranslationConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value == null)
        {
            return String.Empty;
        }

        var key = value is string s ? s : value.ToString();
        if (String.IsNullOrEmpty(key))
        {
            return String.Empty;
        }

        try
        {
            return Lng.Elem(key);
        }
        catch
        {
            return key;
        }
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
