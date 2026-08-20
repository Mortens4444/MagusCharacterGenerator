using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.GameSystem.CombatModifiers;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Shaman;

/// <summary>
/// Jégvihar (Sámán — Természeti mágia, Második Törvénykönyv p.127). Calls down a hailstorm mixed
/// with biting cold wind; deals 1D6 SP per round to everyone in the area, cuts visibility to
/// 3-4 meters (ranged weapons unusable) and drops TÉ by 25 and VÉ by 35 for as long as a target
/// stays inside.
/// </summary>
public sealed class IceStorm : ISpell
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Ice storm";

    public MagicSchool School => MagicSchool.Shaman;

    public int? Power => null;

    public int ManaCost => 24;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 230;

    public int DurationInRounds => 6;

    [DiceThrow(ThrowType._1D6)]
    public int GetDamage() => diceThrow._1D6();

    public void OnHit(Attacker caster, Attacker target)
    {
        target.AddTemporaryModifier(new CombatModifier
        {
            AttackValue = -25,
            DefenseValue = -35
        });
    }
}
