using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Élet csókja (Boszorkány — Csókmágia, Első Törvénykönyv p.223-224, Type: Nekromancia). Drains
/// life force through a kiss to heal the witch's own serious wounds. Re-rolls the drain amount for
/// the self-heal since OnHit doesn't receive the already-rolled damage from GetDamage — not
/// perfectly synced with the damage just dealt, but conveys the mechanic (mirrors the Warlock
/// StealLifeForce class's approach).
/// </summary>
public sealed class KissOfLife : IHealingSpell
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Kiss of life";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => null;

    public int ManaCost => 22;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 5;

    public int DurationInRounds => 1;

    [DiceThrow(ThrowType._1D6)]
    public int GetDamage() => diceThrow._1D6();

    public void OnHit(Attacker caster, Attacker target)
    {
        caster.ActualHealthPoints += diceThrow._1D6();
    }
}
