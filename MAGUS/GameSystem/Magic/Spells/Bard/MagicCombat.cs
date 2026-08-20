using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Bard;

/// <summary>
/// Bűvharc (Bárd — Fénymágia, Első Törvénykönyv p.141). The bard's weapon hand fades from view,
/// its illusory image detaching to fight with a life of its own, confusing the opponent in melee.
/// The book's exact combat effect on the opponent wasn't quantified as a flat modifier, so this
/// is flavor-only (no OnHit). Duration is kör/szint in the book; level-1 baseline shown, not
/// level-scaled.
/// </summary>
public sealed class MagicCombat : ISpell
{
    public string Name => "Magic combat";

    public MagicSchool School => MagicSchool.Bard;

    public int? Power => null;

    public int ManaCost => 16;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 1;

    public int DurationInRounds => 1;

    public int GetDamage() => 0;
}
