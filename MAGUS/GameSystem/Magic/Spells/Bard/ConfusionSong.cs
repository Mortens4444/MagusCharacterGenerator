using MAGUS.Enums;
using MAGUS.GameSystem.CombatModifiers;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Bard;

/// <summary>
/// Zavarodottság dala (Bárd — Dalmágia, Első Törvénykönyv p.134-135). Anyone within 10 láb who
/// hears the song and fails their resistance becomes completely confused, unable to decide what
/// to do. The book only calls for a flat -25 to Attack value (TÉ); this applies the same -25 to
/// all four combat values for simplicity, since the target is described as generally unable to
/// act coherently, not just less accurate.
/// </summary>
public sealed class ConfusionSong : ISpell
{
    private const int Penalty = 25;

    public string Name => "Confusion song";

    public MagicSchool School => MagicSchool.Bard;

    public int? Power => 4;

    public int ManaCost => 6;

    public int PowerBonusPerManaPoint => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Mental;

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
