using Mtf.LanguageService;
using System.Globalization;

namespace MAGUS.Assistant.Converters;

/// <summary>
/// "Must be completed within {0} hours of accepting." as one translatable unit, bound to
/// Quest.TimeLimitHours - a FormattedString of three Spans ("Must be completed within ", TimeLimitHours,
/// " hours of accepting.") used to build this instead, which meant the two text fragments around the
/// number were each their own translation entry with no way to reposition the number for a language
/// that phrases a duration differently.
/// </summary>
internal sealed class QuestTimeLimitConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is not double hours)
        {
            return String.Empty;
        }

        return String.Format(Lng.Elem("Must be completed within {0} hours of accepting."), hours);
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) => throw new NotSupportedException();
}
