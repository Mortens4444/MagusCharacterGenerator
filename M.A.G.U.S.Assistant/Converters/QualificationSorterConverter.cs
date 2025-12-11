using M.A.G.U.S.GameSystem.Qualifications;
using M.A.G.U.S.Qualifications;
using Mtf.LanguageService.MAUI;
using System.Globalization;

namespace M.A.G.U.S.Assistant.Converters;

internal class QualificationSorterConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is IEnumerable<Qualification> collection)
        {
            return collection.OrderBy(q => q.ActualLevel).ThenBy(q => Lng.Elem(q.Name)).ToList();
        }
        if (value is IEnumerable<ISpecialQualification> specailCollection)
        {
            return specailCollection.OrderBy(q => Lng.Elem(q.Name)).ToList();
        }
        if (value is IEnumerable<PercentQualification> percentCollection)
        {
            return percentCollection.OrderBy(q => Lng.Elem(q.Name)).ToList();
        }
        return value;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}