using MAGUS.Enums;
using MAGUS.GameSystem.CombatModifiers;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Füstidézés (Boszorkány — Anyagi Mágia, Első Törvénykönyv p.208, 229). Fills the air around the
/// witch with choking black smoke. Matches the book's -50 Célzó Érték / -25 melee TÉ penalties for
/// anyone caught inside (the witch herself is unaffected, not modeled).
/// </summary>
public sealed class SmokeCall : ISpell
{
    public string Name => "Smoke call";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => null;

    public int ManaCost => 5;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 3;

    public int DurationInRounds => 3;

    public int GetDamage() => 0;

    public void OnHit(Attacker caster, Attacker target)
    {
        target.AddTemporaryModifier(new CombatModifier
        {
            AttackValue = -25,
            DefenseValue = 0,
            InitiateValue = 0,
            AimValue = -50
        });
    }
}
