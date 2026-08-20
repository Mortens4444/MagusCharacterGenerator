using MAGUS.Enums;
using MAGUS.GameSystem.CombatModifiers;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Bódulat (Boszorkány — Mentálmágia, Első Törvénykönyv p.217). Dulls the target's mind on a
/// failed Mental resistance roll. Book escalates the penalty over the first 3 rounds (KÉ -15,
/// then all values -25 more, then -25 more again) before stabilizing for rounds 4-6; the final
/// stabilized penalty is shown flat for the whole duration rather than ramping up. Book's exact
/// Mana cost was illegible in the scanned source; 6 is an estimate consistent with similarly-
/// scoped Mentálmágia spells.
/// </summary>
public sealed class Daze : ISpell
{
    public string Name => "Daze";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => 3;

    public int ManaCost => 6;

    public int PowerBonusPerManaPoint => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Mental;

    public int CastingTimeInSegments => 10;

    public int DurationInRounds => 6;

    public int GetDamage() => 0;

    public void OnHit(Attacker caster, Attacker target)
    {
        target.AddTemporaryModifier(new CombatModifier
        {
            InitiateValue = -15,
            AttackValue = -20,
            DefenseValue = -20,
            AimValue = -20
        });
    }
}
