using MAGUS.Enums;
using MAGUS.GameSystem.CombatModifiers;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Shaman;

/// <summary>
/// Démoni hatalom - képességnövelés (Sámán — Szabad mágia, Második Törvénykönyv p.123-124). Lets
/// the shaman temporarily raise one of their own physical abilities (any but Beauty); pushing past
/// 20 knocks them out for 1D6 hours once the spell ends. The book prices each +1 through a table
/// (+1 costs 1 Mp/1 FP, up to +6 for 21 Mp/13 FP); collapsed here to a single representative +3
/// tier (4 Mp, FP ignored) applied as a flat bonus to all four combat values rather than to a raw
/// ability score.
/// </summary>
public sealed class FiendishVigor : ISpell
{
    private const int Bonus = 3;

    public string Name => "Fiendish vigor";

    public MagicSchool School => MagicSchool.Shaman;

    public int? Power => null;

    public int ManaCost => 4;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 8;

    public int DurationInRounds => 6;

    public int GetDamage() => 0;

    public void OnHit(Attacker caster, Attacker target)
    {
        target.AddTemporaryModifier(new CombatModifier
        {
            AttackValue = Bonus,
            DefenseValue = Bonus,
            InitiateValue = Bonus,
            AimValue = Bonus
        });
    }
}
