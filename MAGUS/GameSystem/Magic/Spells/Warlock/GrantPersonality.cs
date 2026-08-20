using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Warlock;

/// <summary>
/// Személyiséggel felruházás (Boszorkánymester — Nekromancia, Első Törvénykönyv p.260). Places a
/// wandering reincarnation-displaced soul into a mindless undead, giving it full independent
/// personality and free will — the resulting creature is not necessarily loyal to the caster.
/// Duration is k6+szint nap in the book; a representative baseline shown, not level-scaled or
/// randomized. This codebase has no controllable-undead-minion or creature-summoning system; this
/// class exists only as a spellbook/catalog entry with no simulated mechanical effect.
/// </summary>
public sealed class GrantPersonality : ISpell
{
    public string Name => "Grant personality";

    public MagicSchool School => MagicSchool.Warlock;

    public int? Power => null;

    public int ManaCost => 100;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 100;

    public int DurationInRounds => 8640;

    public int GetDamage() => 0;
}
