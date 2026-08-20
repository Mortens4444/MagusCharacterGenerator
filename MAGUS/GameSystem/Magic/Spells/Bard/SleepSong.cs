using MAGUS.Enums;
using MAGUS.GameSystem.CombatModifiers;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Bard;

/// <summary>
/// Álom dala (Bárd — Dalmágia, Első Törvénykönyv p.134). Anyone within 10 láb who hears the song
/// and fails their resistance falls into a deep magical sleep, wakeable only by magic for about
/// 15 rounds. Represented as a near-total combat-value penalty rather than a true
/// unconscious/asleep state, since Attacker has no such flag.
/// </summary>
public sealed class SleepSong : ISpell
{
    private const int Penalty = 50;

    public string Name => "Sleep song";

    public MagicSchool School => MagicSchool.Bard;

    public int? Power => 6;

    public int ManaCost => 12;

    public int PowerBonusPerManaPoint => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Mental;

    public int CastingTimeInSegments => 30;

    public int DurationInRounds => 15;

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
