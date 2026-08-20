using MAGUS.Enums;
using MAGUS.GameSystem.CombatModifiers;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Warlock;

/// <summary>
/// Homokvihar (Boszorkánymester — Természeti Mágia, Első Törvénykönyv p.254). Only usable in or
/// within 50 miles of a desert. Visibility drops to 1 láb for anyone caught in the storm, ranged
/// weapons become unusable (not separately modeled), and combat suffers per the book's TÉ -20 /
/// VÉ -30 penalties, applied here on hit via CombatModifier.
/// </summary>
public sealed class Sandstorm : ISpell
{
    public string Name => "Sandstorm";

    public MagicSchool School => MagicSchool.Warlock;

    public int? Power => null;

    public int ManaCost => 45;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 100;

    public int DurationInRounds => 270;

    public int GetDamage() => 0;

    public void OnHit(Attacker caster, Attacker target)
    {
        target.AddTemporaryModifier(new CombatModifier
        {
            AttackValue = -20,
            DefenseValue = -30,
            InitiateValue = 0,
            AimValue = -20
        });
    }
}
