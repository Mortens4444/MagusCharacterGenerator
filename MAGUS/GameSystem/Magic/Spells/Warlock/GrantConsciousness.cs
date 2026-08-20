using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Warlock;

/// <summary>
/// Tudattal felruházás (Boszorkánymester — Nekromancia, Első Törvénykönyv p.260). Summons the
/// departed's own soul into their remains (if the caster holds a bone or relic), restoring their
/// memories, magic, and Psi — loyal to the caster only if the caster originally created the undead
/// body. Duration is k6+szint nap in the book; a representative baseline shown, not level-scaled
/// or randomized. This codebase has no controllable-undead-minion or creature-summoning system;
/// this class exists only as a spellbook/catalog entry with no simulated mechanical effect.
/// </summary>
public sealed class GrantConsciousness : ISpell
{
    public string Name => "Grant consciousness";

    public MagicSchool School => MagicSchool.Warlock;

    public int? Power => null;

    public int ManaCost => 55;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 60;

    public int DurationInRounds => 8640;

    public int GetDamage() => 0;
}
