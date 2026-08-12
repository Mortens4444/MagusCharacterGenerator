using MAGUS.GameSystem;
using Mtf.LanguageService;
using System.Globalization;

namespace MAGUS.Assistant.Converters;

internal sealed class AttackModeNameConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        => value is Attack attack ? Lng.Elem(attack.Name) : Lng.Elem("Auto (first attack)");

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        => throw new NotSupportedException();
}
