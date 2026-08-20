using MAGUS.Enums;
using MAGUS.GameSystem.CombatModifiers;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Gyűlölet (Boszorkány — Asztrálmágia, Első Törvénykönyv p.213). Kindles fierce hatred toward a
/// named target in every affected victim, who will attack on sight and fight to the death. Matches
/// the book's KÉ+3 TÉ+10 VÉ-20 CÉ-20 exactly. Duration is "1 óra vagy a gyűlölt lény pusztulásáig"
/// (1 hour or until the hated creature dies); the death-clause isn't modeled.
/// </summary>
public sealed class Hatred : ISpell
{
    public string Name => "Hatred";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => 3;

    public int ManaCost => 15;

    public int PowerBonusPerManaPoint => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 10;

    public int DurationInRounds => 360;

    public int GetDamage() => 0;

    public void OnHit(Attacker caster, Attacker target)
    {
        target.AddTemporaryModifier(new CombatModifier
        {
            AttackValue = 10,
            DefenseValue = -20,
            InitiateValue = 3,
            AimValue = -20
        });
    }
}
