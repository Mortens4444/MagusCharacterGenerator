using MAGUS.Enums;
using MAGUS.GameSystem.CombatModifiers;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Fire;

/// <summary>
/// Füstmarás (Tűzvarázsló, Első Törvénykönyv p.277). Turns an existing fire's light and heat
/// into choking, eye-stinging smoke that also chokes visibility and aim. Represents the smoke's
/// combat penalties (aim/melee) as a flat modifier rather than the book's separate
/// ranged-miss/melee-penalty/Egészségpróba rules. Fire-school damage bypasses magic resistance
/// entirely per the rulebook (p.267), hence Power is null.
/// </summary>
public sealed class SmokeSearing : ISpell
{
    private const int Penalty = 25;

    public string Name => "Smoke searing";

    public MagicSchool School => MagicSchool.Fire;

    public int? Power => null;

    public int ManaCost => 2;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 1;

    public int DurationInRounds => 6;

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
