using Mtf.Extensions;
using Mtf.LanguageService;
using System.Globalization;

namespace M.A.G.U.S.Assistant.Converters;

public class EnumDescriptionTranslationConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value == null)
        {
            return String.Empty;
        }

        var type = value.GetType();
        if (!type.IsEnum)
        {
            return value.ToString();
        }

        var description = type.GetMember(value.ToString()).GetDescription();
        return Lng.Elem(description);
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value;
    }
}
