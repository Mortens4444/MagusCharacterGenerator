using M.A.G.U.S.GameSystem.Qualifications;
using Mtf.LanguageService.MAUI;
using System.Globalization;

namespace M.A.G.U.S.Assistant.Converters;

internal class SpecialQualificationNameConverter : IValueConverter
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
