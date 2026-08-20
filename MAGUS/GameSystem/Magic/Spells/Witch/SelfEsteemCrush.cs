using MAGUS.Enums;
using MAGUS.GameSystem.CombatModifiers;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Önbecsülés eltiprása (Boszorkány — Asztrálmágia, Első Törvénykönyv p.211). Crushes the target's
/// self-worth, making them defer to everyone and avoid decisions or combat. Duration is level-
/// difference-based (1 day per level the caster exceeds the target, else 1 hour) in the book;
/// approximated here as a flat 1-hour (360-round) duration.
/// </summary>
public sealed class SelfEsteemCrush : ISpell
{
    private const int Penalty = 15;

    public string Name => "Self-esteem crush";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => 9;

    public int ManaCost => 25;

    public int PowerBonusPerManaPoint => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 10;

    public int DurationInRounds => 360;

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
