using System.Globalization;

namespace M.A.G.U.S.Assistant.Converters;

internal sealed class IsDefaultCharacterConverter : IMultiValueConverter
{
    public object? Convert(object[]? values, Type targetType, object? parameter, CultureInfo culture)
    {
        if (values is not { Length: 2 } || values[0] is not string name)
        {
            return "☆";
        }

        var defaultName = values[1] as string;

        return !String.IsNullOrEmpty(name) && name == defaultName ? "★" : "☆";
    }

    public object[] ConvertBack(object? value, Type[] targetTypes, object? parameter, CultureInfo culture) => throw new NotSupportedException();
}
