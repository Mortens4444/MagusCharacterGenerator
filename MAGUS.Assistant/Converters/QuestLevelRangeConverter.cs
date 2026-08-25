using MAGUS.GameSystem.Quests;
using Mtf.LanguageService;
using System.Globalization;

namespace MAGUS.Assistant.Converters;

/// <summary>
/// "Suggested level: {0}-{1}" as one translatable unit, bound to the whole Quest (not MinLevel/MaxLevel
/// separately) - a FormattedString of four Spans ("Suggested level: ", MinLevel, "-", MaxLevel) used to
/// build this instead, which meant "Suggested level: " and "-" were each their own translation entry
/// with no way to reorder the numbers around them for a language that phrases a range differently.
/// </summary>
internal sealed class QuestLevelRangeConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is not Quest quest)
        {
            return String.Empty;
        }

        return String.Format(Lng.Elem("Suggested level: {0}-{1}"), quest.MinLevel, quest.MaxLevel);
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) => throw new NotSupportedException();
}
