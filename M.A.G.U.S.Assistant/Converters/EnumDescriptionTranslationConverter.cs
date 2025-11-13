using Mtf.Extensions;
using Mtf.LanguageService;
using System.Globalization;

namespace M.A.G.U.S.Assistant.Converters;

internal class EnumDescriptionTranslationConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value == null)
        {
            return String.Empty;
        }

        var str = value.ToString() ?? String.Empty;
        var type = value.GetType();
        if (!type.IsEnum)
        {
            return Lng.Elem(str);
        }

        var description = type.GetMember(str).GetDescription();
        return Lng.Elem(description);
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return value;
    }
}
