using System.Globalization;

namespace M.A.G.U.S.Assistant.Converters;

internal class ToolToThicknessConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        // Az ActiveTool (value) és a paraméterként átadott gomb (parameter) összehasonlítása
        if (value != null && parameter != null && value.Equals(parameter))
        {
            return 3.0; // Aktív eszköz: vastagabb keret
        }
        return 0.0; // Inaktív: nincs keret
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) => throw new NotImplementedException();
}
