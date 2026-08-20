using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Bard;

/// <summary>
/// Szépségvarázs (Bárd — Fénymágia, Első Törvénykönyv p.141). Temporarily reshapes the bard's
/// appearance, raising their Beauty to 20. Purely a light-based illusion; self-buff, cosmetic
/// only.
/// </summary>
public sealed class BeautySpell : ISpell
{
    public string Name => "Beauty spell";

    public MagicSchool School => MagicSchool.Bard;

    public int? Power => null;

    public int ManaCost => 12;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 10;

    public int DurationInRounds => 2160;

    public int GetDamage() => 0;
}
