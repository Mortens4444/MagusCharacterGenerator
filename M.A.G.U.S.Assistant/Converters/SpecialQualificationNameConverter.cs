using M.A.G.U.S.GameSystem.Qualifications;
using M.A.G.U.S.Qualifications.Specialities;
using Mtf.LanguageService.MAUI;
using System.Globalization;

namespace M.A.G.U.S.Assistant.Converters;

internal class SpecialQualificationNameConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is KeenHearing kh)
        {
            return $"{Lng.Elem(kh.Name)} ({kh.Multiplier:F1}x)";
        }
        else if (value is KeenSight ks)
        {
            return $"{Lng.Elem(ks.Name)} ({ks.Multiplier:F1}x)";
        }
        else if (value is KeenSmell k)
        {
            return $"{Lng.Elem(k.Name)} ({k.Multiplier:F1}x)";
        }
        else if (value is SpecialQualification sq)
        {
            return Lng.Elem(sq.Name);
        }

        return String.Empty;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return value;
    }
}
