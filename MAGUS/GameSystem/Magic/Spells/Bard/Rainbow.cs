using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Bard;

/// <summary>
/// Szivárvány (Bárd — Fénymágia, Első Törvénykönyv p.146). Conjures a rainbow indistinguishable
/// from a natural one. Duration is 2 perc/szint in the book; level-1 baseline shown, not
/// level-scaled. Purely cosmetic.
/// </summary>
public sealed class Rainbow : ISpell
{
    public string Name => "Rainbow";

    public MagicSchool School => MagicSchool.Bard;

    public int? Power => null;

    public int ManaCost => 4;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 10;

    public int DurationInRounds => 12;

    public int GetDamage() => 0;
}
