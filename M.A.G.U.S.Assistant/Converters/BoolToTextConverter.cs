using Mtf.LanguageService.MAUI;
using System.Globalization;

namespace M.A.G.U.S.Assistant.Converters;

internal sealed class BoolToTextConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is not bool flag || parameter is not string param)
        {
            return String.Empty;
        }

        var parts = param.Split('|');
        if (parts.Length != 2)
        {
            return String.Empty;
        }

        return flag ? Lng.Elem(parts[0]) : Lng.Elem(parts[1]);
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        => throw new NotSupportedException();
}
