using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Warlock;

/// <summary>
/// Húsmaszk (Boszorkánymester — Nekromancia, Első Törvénykönyv p.263). Lets the caster wear a
/// freshly flayed victim's skin to impersonate them; requires 3rd-degree Anatomy skill. Duration
/// is k6+szint óra in the book; a representative baseline shown, not level-scaled or randomized.
/// This codebase has no controllable-undead-minion or creature-summoning system; this class exists
/// only as a spellbook/catalog entry with no simulated mechanical effect.
/// </summary>
public sealed class FleshMask : ISpell
{
    public string Name => "Flesh mask";

    public MagicSchool School => MagicSchool.Warlock;

    public int? Power => null;

    public int ManaCost => 31;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 3600;

    public int DurationInRounds => 360;

    public int GetDamage() => 0;
}
