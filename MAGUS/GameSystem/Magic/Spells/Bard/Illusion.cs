using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Bard;

/// <summary>
/// Illúzió (Bárd — Fénymágia, Első Törvénykönyv p.143). Conjures any image the bard can imagine
/// inside a 1×1 láb column of unlimited height; pure light with no smell, sound or touch. Duration
/// is 15 perc/szint in the book; level-1 baseline shown, not level-scaled.
/// </summary>
public sealed class Illusion : ISpell
{
    public string Name => "Illusion";

    public MagicSchool School => MagicSchool.Bard;

    public int? Power => null;

    public int ManaCost => 4;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 3;

    public int DurationInRounds => 90;

    public int GetDamage() => 0;
}
