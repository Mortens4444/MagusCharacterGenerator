using MAGUS.Enums;
using MAGUS.GameSystem.CombatModifiers;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Bénítás (Boszorkány — Bájolás, Első Törvénykönyv p.222). A touch paralyzes the target; only
/// lasts 1 segment unless immediately followed by Mágikus ölelés (Magical embrace) — that combo
/// requirement isn't enforced here, this represents the paralysis effect alone.
/// </summary>
public sealed class SeductiveParalysis : ISpell
{
    private const int Penalty = -80;

    public string Name => "Seductive paralysis";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => 5;

    public int ManaCost => 2;

    public int PowerBonusPerManaPoint => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Mental;

    public int CastingTimeInSegments => 1;

    public int DurationInRounds => 1;

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
