using System.Globalization;

namespace MAGUS.Assistant.Converters;

/// <summary>
/// Combines Qualification.NeedsSelection/IsSelectable with the page's CanReviseQualificationSelection
/// (see CharacterViewModel) so QualificationsView.xaml's "Choose" button shows for an unset pick
/// regardless of page, but only stays visible on an already-made pick while a character is still being
/// created - a saved character's pick is locked in.
/// </summary>
internal sealed class QualificationChooseButtonVisibleConverter : IMultiValueConverter
{
    public object? Convert(object[]? values, Type targetType, object? parameter, CultureInfo culture)
    {
        if (values is not { Length: 3 } || values[0] is not bool needsSelection || values[1] is not bool isSelectable || values[2] is not bool canRevise)
        {
            return false;
        }

        return needsSelection || (isSelectable && canRevise);
    }

    public object[] ConvertBack(object? value, Type[] targetTypes, object? parameter, CultureInfo culture) => throw new NotSupportedException();
}
