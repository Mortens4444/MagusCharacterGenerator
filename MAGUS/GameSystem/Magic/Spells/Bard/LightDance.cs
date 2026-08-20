using MAGUS.Enums;
using MAGUS.GameSystem.CombatModifiers;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Bard;

/// <summary>
/// Fénytánc (Bárd — Fénymágia, Első Törvénykönyv p.144-145). A dazzling dance of colored lights
/// that fascinates anyone watching within range on a failed Astral resistance roll. Represented
/// as a large combat-value penalty on hit rather than a true "fascinated, ignores everything"
/// state, which this codebase has no concept of. Duration is 2 kör/szint in the book; level-1
/// baseline shown, not level-scaled.
/// </summary>
public sealed class LightDance : ISpell
{
    private const int Penalty = 40;

    public string Name => "Light dance";

    public MagicSchool School => MagicSchool.Bard;

    public int? Power => 6;

    public int ManaCost => 5;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 2;

    public int DurationInRounds => 2;

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
