using MAGUS.Enums;
using MAGUS.GameSystem.CombatModifiers;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Bard;

/// <summary>
/// Nyugalom dala (Bárd — Dalmágia, Első Törvénykönyv p.134). Anyone within 10 láb who hears the
/// song and fails their resistance loses all will to fight and calms down. Book duration is k6
/// (1-6) rounds after the song ends; 3 is the average, not randomized here. Represents the target
/// dropping out of combat (calmed) as a heavy combat-value penalty rather than a true
/// "won't attack" flag, since Attacker has no such state.
/// </summary>
public sealed class CalmingSong : ISpell
{
    private const int Penalty = 30;

    public string Name => "Calming song";

    public MagicSchool School => MagicSchool.Bard;

    public int? Power => 5;

    public int ManaCost => 1;

    public int PowerBonusPerManaPoint => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 60;

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
