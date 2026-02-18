using System.Globalization;

namespace M.A.G.U.S.Assistant.Converters;

internal sealed class FractionConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is not double d || d <= 0)
        {
            return String.Empty;
        }

        const double tolerance = 1e-10;

        for (var denominator = 1; denominator <= 100; denominator++)
        {
            var numerator = d * denominator;

            if (Math.Abs(numerator - Math.Round(numerator)) < tolerance)
            {
                var n = (int)Math.Round(numerator);

                return denominator == 1
                    ? n.ToString(culture)
                    : $"{n} / {denominator}";
            }
        }

        return d.ToString("0.##", culture);
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        => throw new NotSupportedException();
}