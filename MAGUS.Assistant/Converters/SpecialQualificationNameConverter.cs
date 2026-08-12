using MAGUS.GameSystem.Qualifications;
using Mtf.LanguageService;
using System.Globalization;

namespace MAGUS.Assistant.Converters;

internal sealed class SpecialQualificationNameConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is SpecialQualification sq)
        {
            return Lng.Elem(sq.Name) + sq.ToString();
        }

        return String.Empty;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) => value;
}
