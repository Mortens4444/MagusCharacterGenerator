using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Warlock;

/// <summary>
/// Életerő rablás (Boszorkánymester — Nekromancia, Első Törvénykönyv p.258). Re-rolls the drain
/// amount for the self-heal since OnHit doesn't receive the already-rolled damage from GetDamage —
/// not perfectly synced with the damage just dealt, but conveys the vampiric mechanic.
/// </summary>
public sealed class StealLifeForce : ISpell
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Steal life force";

    public MagicSchool School => MagicSchool.Warlock;

    public int? Power => null;

    public int ManaCost => 14;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 2;

    public int DurationInRounds => 1;

    [DiceThrow(ThrowType._2D10)]
    public int GetDamage() => diceThrow._2D10();

    public void OnHit(Attacker caster, Attacker target)
    {
        caster.ActualHealthPoints += diceThrow._2D10();
    }
}
