using MAGUS.Enums;
using MAGUS.GameSystem.CombatModifiers;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Shaman;

/// <summary>
/// Sötétmaszk (Sámán — Maszkmágia, Második Törvénykönyv p.135-136). An amorphous bone mask carved
/// with the shaman's vision of primal human dread. Once empowered (20 Mp + 7 FP per the book's
/// stat block; recharging the mask itself afterward costs a separate 28 Mp + 1 FP "Felruházás",
/// not modeled), anyone the wearer looks at within 20 meters must beat the mask's Erősség on an
/// Astral resistance roll or be overcome with terror - fleeing if possible, otherwise freezing or
/// curling up, and refusing to fight the shaman for the rest of the encounter and for 1D6 days
/// after. Modeled as a severe combat-value penalty on a failed resistance roll.
/// </summary>
public sealed class DarkMask : ISpell
{
    public string Name => "Dark mask";

    public MagicSchool School => MagicSchool.Shaman;

    public int? Power => 25;

    public int ManaCost => 20;

    public int PainTolerancePointCost => 7;

    public int PowerBonusPerManaPoint => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 5;

    public int DurationInRounds => 6;

    public int GetDamage() => 0;

    public void OnHit(Attacker caster, Attacker target)
    {
        target.AddTemporaryModifier(new CombatModifier
        {
            AttackValue = -40,
            DefenseValue = -20,
            InitiateValue = -40,
            AimValue = -40
        });
    }
}
