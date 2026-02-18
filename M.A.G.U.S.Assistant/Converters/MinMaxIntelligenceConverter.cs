using M.A.G.U.S.Enums;
using Mtf.LanguageService.MAUI.Converters;
using System.Globalization;

namespace M.A.G.U.S.Assistant.Converters;

internal class MinMaxIntelligenceConverter : IValueConverter, IMultiValueConverter
{
    private readonly EnumDescriptionTranslationConverter enumConverter = new();

    public object? Convert(object[]? values, Type targetType, object? parameter, CultureInfo culture)
    {
        if (values == null || values.Length < 3)
        {
            return null;
        }

        Intelligence? minIntelligence = values[0] as Intelligence?;
        Intelligence? maxIntelligence = values[1] as Intelligence?;
        Intelligence? intelligence = values[2] as Intelligence?;

        if (minIntelligence.HasValue && maxIntelligence.HasValue)
        {
            var minText = enumConverter.Convert(minIntelligence.Value, targetType, parameter, culture).ToString();
            var maxText = enumConverter.Convert(maxIntelligence.Value, targetType, parameter, culture).ToString();

            return $"{minText} - {maxText}";
        }
        else if (minIntelligence.HasValue)
        {
            return enumConverter.Convert(minIntelligence.Value, targetType, parameter, culture);
        }
        else if (maxIntelligence.HasValue)
        {
            return enumConverter.Convert(maxIntelligence.Value, targetType, parameter, culture);
        }
        else if (intelligence.HasValue)
        {
            return enumConverter.Convert(intelligence.Value, targetType, parameter, culture).ToString();
        }
        else
        {
            return String.Empty;
        }
    }

    public object[]? ConvertBack(object? value, Type[] targetTypes, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }

    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is Intelligence intelligence)
        {
            return enumConverter.Convert(intelligence, targetType, parameter, culture);
        }
        return string.Empty;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}