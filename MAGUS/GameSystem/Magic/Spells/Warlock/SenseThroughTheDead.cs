using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Warlock;

/// <summary>
/// Érzékelés holtakon keresztül (Boszorkánymester — Nekromancia, Első Törvénykönyv p.263). Lets
/// the caster see/hear through an undead creature they created and gave intellect/personality/
/// consciousness to. Duration is k6+szint óra in the book; a representative baseline shown, not
/// level-scaled or randomized. This codebase has no controllable-undead-minion or creature-
/// summoning system; this class exists only as a spellbook/catalog entry with no simulated
/// mechanical effect.
/// </summary>
public sealed class SenseThroughTheDead : ISpell
{
    public string Name => "Sense through the dead";

    public MagicSchool School => MagicSchool.Warlock;

    public int? Power => null;

    public int ManaCost => 26;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 60;

    public int DurationInRounds => 360;

    public int GetDamage() => 0;
}
