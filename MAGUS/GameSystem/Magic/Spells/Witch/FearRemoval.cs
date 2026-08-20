using MAGUS.Enums;
using MAGUS.GameSystem.CombatModifiers;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Félelem elűzése (Boszorkány — Asztrálmágia, Első Törvénykönyv p.212). Strips away not just fear
/// of the unknown but basic self-preserving caution, turning the target into a cheerful, reckless
/// near-suicide risk. Matches the book's VÉ dropping to a quarter (approximated as -45). Duration
/// is level-difference-based (1 day per level the caster exceeds the target, else 1 hour) in the
/// book; approximated here as a flat 1-hour (360-round) duration.
/// </summary>
public sealed class FearRemoval : ISpell
{
    public string Name => "Fear removal";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => 6;

    public int ManaCost => 55;

    public int PowerBonusPerManaPoint => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 10;

    public int DurationInRounds => 360;

    public int GetDamage() => 0;

    public void OnHit(Attacker caster, Attacker target)
    {
        target.AddTemporaryModifier(new CombatModifier
        {
            AttackValue = 0,
            DefenseValue = -45,
            InitiateValue = 0,
            AimValue = 0
        });
    }
}
