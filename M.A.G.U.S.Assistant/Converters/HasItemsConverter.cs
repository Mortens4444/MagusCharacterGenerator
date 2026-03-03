using System.Collections;
using System.Globalization;

namespace M.A.G.U.S.Assistant.Converters;

internal sealed class HasItemsConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value == null)
        {
            return false;
        }

        if (value is ICollection coll)
        {
            return coll.Count > 0;
        }

        if (value is IEnumerable enumerable)
        {
            return enumerable.Cast<object>().Any();
        }

        return false;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) => throw new NotSupportedException();
}