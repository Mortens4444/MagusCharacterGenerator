using MAGUS.Enums;
using MAGUS.GameSystem.CombatModifiers;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Bard;

/// <summary>
/// Félelmes fegyver (Bárd — Fénymágia, Első Törvénykönyv p.141). Wreathes the bard's drawn weapon
/// in dancing light (flame, glow, ...), no damage of its own, but unsettling to an opponent who
/// hasn't seen it before. Book gives separate TÉ -5/VÉ -5 (or -15/-5 if the target is known to
/// fear the weapon's apparent element); simplified to a flat -5 across all four combat values.
/// </summary>
public sealed class FearsomeWeapon : ISpell
{
    private const int Penalty = 5;

    public string Name => "Fearsome weapon";

    public MagicSchool School => MagicSchool.Bard;

    public int? Power => null;

    public int ManaCost => 3;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 1;

    public int DurationInRounds => 8;

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
