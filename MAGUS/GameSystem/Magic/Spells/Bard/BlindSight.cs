using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Bard;

/// <summary>
/// Vakon látás (Bárd — Fénymágia, Első Törvénykönyv p.144). Lets the bard perceive their
/// surroundings without sight (e.g. blindfolded), similar to infravision. Duration is 5 perc/szint
/// in the book; level-1 baseline shown, not level-scaled.
/// </summary>
public sealed class BlindSight : ISpell
{
    public string Name => "Blind-sight";

    public MagicSchool School => MagicSchool.Bard;

    public int? Power => null;

    public int ManaCost => 35;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 30;

    public int DurationInRounds => 30;

    public int GetDamage() => 0;
}
