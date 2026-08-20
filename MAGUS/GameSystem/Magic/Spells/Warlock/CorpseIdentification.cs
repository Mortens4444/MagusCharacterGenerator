using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Warlock;

/// <summary>
/// Azonosítás (Boszorkánymester — Nekromancia, Első Törvénykönyv p.261). Reveals a corpse's life
/// history, origin, and cause/circumstances of death after long concentration. Casting time is
/// 2k10 kör in the book; the average roll (11 kör = 110 segments) is shown rather than randomized.
/// This codebase has no controllable-undead-minion or creature-summoning system; this class exists
/// only as a spellbook/catalog entry with no simulated mechanical effect.
/// </summary>
public sealed class CorpseIdentification : ISpell
{
    public string Name => "Corpse identification";

    public MagicSchool School => MagicSchool.Warlock;

    public int? Power => null;

    public int ManaCost => 44;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 110;

    public int DurationInRounds => 1;

    public int GetDamage() => 0;
}
