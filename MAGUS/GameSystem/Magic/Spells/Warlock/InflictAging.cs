using MAGUS.Enums;
using MAGUS.GameSystem.CombatModifiers;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Warlock;

/// <summary>
/// Öregedés (Boszorkánymester — Nekromancia, Első Törvénykönyv p.257-258). Book offers a cheaper
/// temporary aging (28 + 1 Mp per year aged, lasting 1 day/level) or a pricier permanent version
/// (40 Mp + 9/year); the temporary version's cost and duration are shown, level-1 baseline, not
/// level-scaled. Represents physical frailty as a flat combat-value penalty.
/// </summary>
public sealed class InflictAging : ISpell
{
    public string Name => "Inflict aging";

    public MagicSchool School => MagicSchool.Warlock;

    public int? Power => null;

    public int ManaCost => 28;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 50;

    public int DurationInRounds => 8640;

    public int GetDamage() => 0;

    public void OnHit(Attacker caster, Attacker target)
    {
        target.AddTemporaryModifier(new CombatModifier
        {
            AttackValue = -15,
            DefenseValue = -15,
            InitiateValue = -15,
            AimValue = -15
        });
    }
}
