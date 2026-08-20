using MAGUS.Enums;
using MAGUS.GameSystem.CombatModifiers;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Bard;

/// <summary>
/// Aura (Bárd — Fénymágia, Első Törvénykönyv p.140). Cast on self it's a cosmetic beauty buff
/// (not modeled); cast on an enemy it wraps them in a thin glowing outline that makes them easier
/// to hit (book: VÉ -10 melee / -20 ranged), simplified here to a flat -15 across all four combat
/// values.
/// </summary>
public sealed class Aura : ISpell
{
    private const int Penalty = 15;

    public string Name => "Aura";

    public MagicSchool School => MagicSchool.Bard;

    public int? Power => null;

    public int ManaCost => 3;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 1;

    public int DurationInRounds => 10;

    public int GetDamage() => 0;

    public void OnHit(Attacker caster, Attacker target)
    {
        target.AddTemporaryModifier(new CombatModifier
        {
            AttackValue = -Penalty,
            DefenseValue = -Penalty,
            InitiateValue = -Penalty,
            AimValue = -Penalty
        });
    }
}
