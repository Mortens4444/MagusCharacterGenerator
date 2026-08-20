using MAGUS.Enums;
using MAGUS.GameSystem.CombatModifiers;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Bard;

/// <summary>
/// Fegyver (Bárd — Fénymágia, Első Törvénykönyv p.148). Hides the bard's real weapon behind the
/// illusory image of a different one, changeable round to round. Book gives the opponent -10 VÉ /
/// -5 TÉ from the confusing shape-shifting weapon illusion; simplified to a flat -10 across all
/// four combat values. Duration is 2 kör/szint in the book; level-1 baseline shown, not
/// level-scaled.
/// </summary>
public sealed class WeaponIllusion : ISpell
{
    private const int Penalty = 10;

    public string Name => "Weapon illusion";

    public MagicSchool School => MagicSchool.Bard;

    public int? Power => null;

    public int ManaCost => 5;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 1;

    public int DurationInRounds => 12;

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
