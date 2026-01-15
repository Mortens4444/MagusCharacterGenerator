using System.Globalization;

namespace M.A.G.U.S.Assistant.Converters;

internal class ColorComparisonConverter : IMultiValueConverter
{
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        if (values.Length == 2 && values[0] is Color selectedColor && values[1] is Color itemColor)
        {
            bool isSelected = Math.Abs(selectedColor.Red - itemColor.Red) < 0.01 &&
                            Math.Abs(selectedColor.Green - itemColor.Green) < 0.01 &&
                            Math.Abs(selectedColor.Blue - itemColor.Blue) < 0.01 &&
                            Math.Abs(selectedColor.Alpha - itemColor.Alpha) < 0.01;

            if (parameter?.ToString() == "Stroke")
            {
                return isSelected ? Colors.DarkCyan : Color.FromArgb("#555555");
            }
            else if (parameter?.ToString() == "Thickness")
            {
                return isSelected ? 4.0 : 1.5;
            }
        }

        return parameter?.ToString() == "Thickness" ? 1.5 : Color.FromArgb("#555555");
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}