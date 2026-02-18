using M.A.G.U.S.Models;
using Mtf.Extensions;
using Mtf.LanguageService.MAUI;
using System.Globalization;

namespace M.A.G.U.S.Assistant.Converters;

internal class SpeedConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is not Speed speed)
        {
            return String.Empty;
        }

        var mode = Lng.Elem(speed.TravelMode.GetDescription()) ?? String.Empty;
        var val = speed.Value?.ToString(CultureInfo.InvariantCulture) ?? String.Empty;
        var desc = Lng.Elem(speed.Description) ?? String.Empty;

        if (!String.IsNullOrWhiteSpace(desc))
        {
            return $"{mode} - {val} - {desc}".TrimEnd('-', ' ');
        }

        return $"{mode} - {val}".TrimEnd('-', ' ');
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return Binding.DoNothing;
    }
}
