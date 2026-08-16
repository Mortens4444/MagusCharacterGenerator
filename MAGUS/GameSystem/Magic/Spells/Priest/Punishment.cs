using MAGUS.Enums;
using MAGUS.GameSystem.CombatModifiers;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Priest;

/// <summary>
/// Bűntetés (Szférikus — Lélek). Rulebook: a crippling, cramping paralysis that heavily penalizes
/// the target's Strength/Quickness/Dexterity and every combat value, and prevents spellcasting.
/// Duration is "1 kör/szint" (per caster level, not modeled per-level here — approximated as a
/// flat few rounds). Deals no direct damage; represented instead as a large combat-value penalty
/// applied to the target on a successful hit, via the same TemporaryModifiers mechanism used for
/// direction bonuses and PsiPush.
/// </summary>
public sealed class Punishment : ISpell
{
    private const int Penalty = 30;

    public string Name => "Punishment";

    public MagicSchool School => MagicSchool.Priest;

    public Sphere[] Spheres => [Sphere.Soul];

    public int? Power => 15;

    public int ManaCost => 12;

    public int PowerBonusPerManaPoint => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Mental;

    public int CastingTimeInSegments => 3;

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
