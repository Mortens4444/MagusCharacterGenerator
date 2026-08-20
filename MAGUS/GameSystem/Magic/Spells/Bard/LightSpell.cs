using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Bard;

/// <summary>
/// Fényvarázs (Bárd — Fénymágia, Első Törvénykönyv p.142). Changes ambient illumination within a
/// 15-láb radius, from total darkness up to bright daylight, in any color, without ever blinding
/// or damaging anyone (except creatures specifically vulnerable to light). Duration is perc/szint
/// in the book; level-1 baseline shown, not level-scaled.
/// </summary>
public sealed class LightSpell : ISpell
{
    public string Name => "Light spell";

    public MagicSchool School => MagicSchool.Bard;

    public int? Power => null;

    public int ManaCost => 3;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 10;

    public int DurationInRounds => 6;

    public int GetDamage() => 0;
}
