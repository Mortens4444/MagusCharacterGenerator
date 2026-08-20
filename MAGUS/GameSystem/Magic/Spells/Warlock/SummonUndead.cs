using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Warlock;

/// <summary>
/// Élőholt idézés (Boszorkánymester — Nekromancia, Első Törvénykönyv p.259). Calls all undead
/// within a 150-láb sphere to gather around the caster; only mindless/semi-intelligent ones (up to
/// caster level in number) actually obey. This codebase has no controllable-undead-minion or
/// creature-summoning system; this class exists only as a spellbook/catalog entry with no
/// simulated mechanical effect.
/// </summary>
public sealed class SummonUndead : ISpell
{
    public string Name => "Summon undead";

    public MagicSchool School => MagicSchool.Warlock;

    public int? Power => null;

    public int ManaCost => 18;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 20;

    public int DurationInRounds => 10;

    public int GetDamage() => 0;
}
