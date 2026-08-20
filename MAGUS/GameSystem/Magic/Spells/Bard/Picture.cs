using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Bard;

/// <summary>
/// Kép (Bárd — Fénymágia, Első Törvénykönyv p.148). Copies an existing picture or piece of
/// writing as a perfect illusory duplicate. Duration is 15 perc/szint in the book (extendable to
/// permanent for extra mana, not modeled); level-1 baseline shown.
/// </summary>
public sealed class Picture : ISpell
{
    public string Name => "Picture";

    public MagicSchool School => MagicSchool.Bard;

    public int? Power => null;

    public int ManaCost => 5;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 10;

    public int DurationInRounds => 90;

    public int GetDamage() => 0;
}
