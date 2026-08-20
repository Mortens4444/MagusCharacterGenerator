using MAGUS.Enums;
using MAGUS.GameSystem.CombatModifiers;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Bard;

/// <summary>
/// Bénítás dala (Bárd — Dalmágia, Első Törvénykönyv p.135). Anyone within 10 láb who has heard
/// the song for at least 2 rounds and fails their resistance becomes completely fixated on the
/// music and immobile. Represents the book's total immobilization as a near-total combat-value
/// penalty, since Attacker has no true "paralyzed" state.
/// </summary>
public sealed class ParalysisSong : ISpell
{
    private const int Penalty = 60;

    public string Name => "Paralysis song";

    public MagicSchool School => MagicSchool.Bard;

    public int? Power => 7;

    public int ManaCost => 8;

    public int PowerBonusPerManaPoint => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Mental;

    public int CastingTimeInSegments => 50;

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
