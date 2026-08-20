using MAGUS.Enums;
using MAGUS.GameSystem.CombatModifiers;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Akaratrablás (Boszorkány — Mentálmágia, Első Törvénykönyv p.217). Robs the target of
/// initiative and decision-making on a failed Mental resistance roll — they can still fight
/// defensively but take a penalty on every roll and otherwise stand motionless. Duration is
/// kör/szint in the book; level-1 baseline shown, not level-scaled.
/// </summary>
public sealed class WillDrain : ISpell
{
    private const int Penalty = -15;

    public string Name => "Will drain";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => 1;

    public int ManaCost => 6;

    public int PowerBonusPerManaPoint => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Mental;

    public int CastingTimeInSegments => 2;

    public int DurationInRounds => 6;

    public int GetDamage() => 0;

    public void OnHit(Attacker caster, Attacker target)
    {
        target.AddTemporaryModifier(new CombatModifier
        {
            AttackValue = Penalty,
            DefenseValue = Penalty,
            InitiateValue = Penalty,
            AimValue = Penalty
        });
    }
}
