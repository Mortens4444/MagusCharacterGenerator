using MAGUS.Enums;
using MAGUS.GameSystem.CombatModifiers;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Bard;

/// <summary>
/// Vakság okozás (Bárd — Fénymágia, Első Törvénykönyv p.140). The target's sight is stripped away
/// entirely until the spell ends. Represented as a heavy combat-value penalty rather than a true
/// blind flag, since Attacker has no such state.
/// </summary>
public sealed class CauseBlindness : ISpell
{
    private const int Penalty = 40;

    public string Name => "Cause blindness";

    public MagicSchool School => MagicSchool.Bard;

    public int? Power => null;

    public int ManaCost => 8;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 1;

    public int DurationInRounds => 3;

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
