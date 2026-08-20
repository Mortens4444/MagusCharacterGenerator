using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Warlock;

/// <summary>
/// Halottak nyelve (Boszorkánymester — Nekromancia, Első Törvénykönyv p.260). Lets the caster
/// speak and understand the Tongue of the Dead, needed to converse with intelligent/semi-
/// intelligent undead. This codebase has no controllable-undead-minion or creature-summoning
/// system; this class exists only as a spellbook/catalog entry with no simulated mechanical effect.
/// </summary>
public sealed class TongueOfTheDead : ISpell
{
    public string Name => "Tongue of the dead";

    public MagicSchool School => MagicSchool.Warlock;

    public int? Power => null;

    public int ManaCost => 5;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 3;

    public int DurationInRounds => 12;

    public int GetDamage() => 0;
}
