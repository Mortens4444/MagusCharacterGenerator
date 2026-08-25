using Mtf.LanguageService;
using System.Globalization;

namespace MAGUS.Assistant.Converters;

/// <summary>
/// Translates a literal English caption passed via ConverterParameter, ignoring the bound value - for
/// static Text/Span captions inside a CollectionView's DataTemplate. Translator.Translate (the
/// NotifierPage auto-translate pass run in PageNotifier.Register) can never reach those: for a
/// CollectionView it walks the bound data items (e.g. Quest), not the realized per-row visual tree, so
/// a plain Text="Accept quest" is silently skipped. The bound value still has to be something (Text
/// itself can't be a plain string once this converter is used), so callers pass the item itself
/// ("{Binding .}") purely to have a valid binding source.
/// </summary>
internal sealed class LiteralTranslationConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        var text = parameter as string;
        return String.IsNullOrEmpty(text) ? String.Empty : Lng.Elem(text);
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) => throw new NotSupportedException();
}
