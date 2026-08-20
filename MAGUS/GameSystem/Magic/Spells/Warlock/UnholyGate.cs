using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Warlock;

/// <summary>
/// Szentségtelen kapu (Boszorkánymester — Nekromancia, Első Törvénykönyv p.261). One of the most
/// dangerous demon-summoning rites — tears a rift between planes that random demons pour through
/// (GM's choice, usually minor ones); the caster has an 85% chance of dying in the process, in
/// which case the gate stays open. Closing it afterward costs an additional 65 Mana-pont (not
/// separately modeled as its own spell here). This codebase has no controllable-undead-minion or
/// creature-summoning system; this class exists only as a spellbook/catalog entry with no
/// simulated mechanical effect.
/// </summary>
public sealed class UnholyGate : ISpell
{
    public string Name => "Unholy gate";

    public MagicSchool School => MagicSchool.Warlock;

    public int? Power => null;

    public int ManaCost => 110;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 50;

    public int DurationInRounds => 1;

    public int GetDamage() => 0;
}
