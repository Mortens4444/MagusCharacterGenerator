using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Warlock;

/// <summary>
/// Értelemmel felruházás (Boszorkánymester — Nekromancia, Első Törvénykönyv p.259-260). Raises a
/// mindless undead's intelligence to 2+k3, enabling it to follow multi-step instructions. Duration
/// is k6+szint nap in the book; a representative baseline shown, not level-scaled or randomized.
/// This codebase has no controllable-undead-minion or creature-summoning system; this class exists
/// only as a spellbook/catalog entry with no simulated mechanical effect.
/// </summary>
public sealed class GrantIntellect : ISpell
{
    public string Name => "Grant intellect";

    public MagicSchool School => MagicSchool.Warlock;

    public int? Power => null;

    public int ManaCost => 45;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 50;

    public int DurationInRounds => 8640;

    public int GetDamage() => 0;
}
