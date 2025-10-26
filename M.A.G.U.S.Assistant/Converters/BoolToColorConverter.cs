using System.Globalization;

namespace M.A.G.U.S.Assistant.Converters;

internal class BoolToColorConverter : IValueConverter
{
    public Color EnabledColor { get; set; } = Colors.White;

    public Color DisabledColor { get; set; } = Colors.Gray;

    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is bool b)
        {
            return b ? EnabledColor : DisabledColor;
        }

        return EnabledColor;
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
