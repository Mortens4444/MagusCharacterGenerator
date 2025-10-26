using M.A.G.U.S.Assistant.Extensions;
using M.A.G.U.S.GameSystem.Valuables;
using Mtf.LanguageService;
using System.Globalization;

namespace M.A.G.U.S.Assistant.Converters;

internal class MoneyToTranslatedStringConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        var money = value as Money;
        if (money is not null)
        {
            return money.ToTranslatedString();
        }

        if (value != null)
        {
            return value.ToString() ?? String.Empty;
        }

        return Lng.Elem("Free");
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) => throw new NotSupportedException();
}
