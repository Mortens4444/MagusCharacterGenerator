using M.A.G.U.S.GameSystem.Qualifications;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Combat;
using M.A.G.U.S.Qualifications.Scientific;
using Mtf.Extensions;
using Mtf.LanguageService.MAUI;
using System.Globalization;

namespace M.A.G.U.S.Assistant.Converters;

internal class QualificationNameConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is LanguageLore ll)
        {
            var text = ll.Language.HasValue
                ? ll.QualificationLevel == QualificationLevel.Base
                    ? $"{Lng.Elem(ll.Name)} - {Lng.Elem(ll.Language.Value.GetDescription())} ({ll.LanguageLevel})"
                    : $"{Lng.Elem(ll.Name)} - {Lng.Elem(ll.Language.Value.GetDescription())}"
                : Lng.Elem(ll.Name);

            return AppendNote(ll, text);
        }

        if (value is AncientTongueLore atl)
        {
            var text = atl.Language.HasValue
                ? $"{Lng.Elem(atl.Name)} - {Lng.Elem(atl.Language.Value.GetDescription())}"
                : Lng.Elem(atl.Name);

            return AppendNote(atl, text);
        }

        if (value is WeaponQualification wq)
        {
            var text = wq.Weapon != null
                ? $"{Lng.Elem(wq.Name)} - {Lng.Elem(wq.Weapon.Name)}"
                : Lng.Elem(wq.Name);

            return AppendNote(wq, text);
        }

        if (value is Qualification qualification)
        {
            return AppendNote(qualification, Lng.Elem(qualification.Name));
        }

        return String.Empty;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return value;
    }

    private static string AppendNote(Qualification qualification, string text)
    {
        return String.IsNullOrWhiteSpace(qualification.Note) ? text : $"{text} ({Lng.Elem(qualification.Note)})";
    }
}
