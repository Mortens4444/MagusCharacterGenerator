using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Warlock;

/// <summary>
/// Életerő átadása (Boszorkánymester — Nekromancia, Első Törvénykönyv p.262). Re-rolls the drain
/// amount for the self-heal since OnHit doesn't receive the already-rolled damage from GetDamage —
/// not perfectly synced with the damage just dealt, but conveys the vampiric mechanic. Book
/// actually banks the drained life force for the caster to reclaim within 48 hours rather than
/// healing immediately; simplified here to an immediate self-heal like Életerő rablás, since the
/// 48-hour banking window can't be represented statelessly.
/// </summary>
public sealed class TransferLifeForce : ISpell
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Transfer life force";

    public MagicSchool School => MagicSchool.Warlock;

    public int? Power => null;

    public int ManaCost => 22;

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
