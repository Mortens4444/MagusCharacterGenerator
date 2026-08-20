using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Warlock;

/// <summary>
/// Életerővel felruházás (Boszorkánymester — Nekromancia, Első Törvénykönyv p.259). Book gives the
/// drained life force to a chosen undead minion as Ép instead of healing the caster; the
/// undead-minion transfer isn't modeled here since this codebase has no controllable-undead-minion
/// system.
/// </summary>
public sealed class BestowLifeForce : ISpell
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Bestow life force";

    public MagicSchool School => MagicSchool.Warlock;

    public int? Power => null;

    public int ManaCost => 25;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 2;

    public int DurationInRounds => 1;

    [DiceThrow(ThrowType._2D10)]
    public int GetDamage() => diceThrow._2D10();
}
