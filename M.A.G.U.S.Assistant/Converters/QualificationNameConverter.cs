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
            if (ll.Language.HasValue)
            {
                if (ll.QualificationLevel == QualificationLevel.Base)
                {
                    return $"{Lng.Elem(ll.Name)} - {Lng.Elem(ll.Language.Value.GetDescription())} ({ll.LanguageLevel})";
                }
                return $"{Lng.Elem(ll.Name)} - {Lng.Elem(ll.Language.Value.GetDescription())}";
            }
            return Lng.Elem(ll.Name);
        }
        else if (value is AncientTongueLore atl)
        {
            if (atl.Language.HasValue)
            {
                return $"{Lng.Elem(atl.Name)} - {Lng.Elem(atl.Language.Value.GetDescription())}";
            }
            return Lng.Elem(atl.Name);
        }
        else if (value is WeaponQualification wq)
        {
            if (wq.Weapon != null)
            {
                return $"{Lng.Elem(wq.Name)} - {Lng.Elem(wq.Weapon.Name)}";
            }
            return Lng.Elem(wq.Name);
        }
        else if (value is Qualification q)
        {
            return Lng.Elem(q.Name);
        }

        return String.Empty;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return value;
    }
}
