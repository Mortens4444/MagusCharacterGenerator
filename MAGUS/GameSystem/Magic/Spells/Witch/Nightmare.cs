using MAGUS.Enums;
using MAGUS.GameSystem.CombatModifiers;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Rémálom (Boszorkány — Lélekvarázs / Álomellenőrző varázslatok, Első Törvénykönyv p.219-220).
/// Dual Asztrális+Mentális resistance in the book, Astral modeled here. Traps the victim in an
/// inescapable 6-hour nightmare with no penalty-free waking; represented as a combat-value
/// penalty for the following period rather than a wounds-don't-heal/points-don't-recover
/// mechanic.
/// </summary>
public sealed class Nightmare : ISpell
{
    private const int Penalty = 25;

    public string Name => "Nightmare";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => 5;

    public int ManaCost => 15;

    public int PowerBonusPerManaPoint => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 10;

    public int DurationInRounds => 2160;

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
