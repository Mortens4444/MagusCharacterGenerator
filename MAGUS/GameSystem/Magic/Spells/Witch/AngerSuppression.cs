using MAGUS.Enums;
using MAGUS.GameSystem.CombatModifiers;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Düh kioltása (Boszorkány — Asztrálmágia, Első Törvénykönyv p.211). Suppresses anger and
/// aggression in the target, who will only fight in self-defense. Duration is level-difference-
/// based (1 day per level the caster exceeds the target, else 1 hour) in the book; approximated
/// here as a flat 1-hour (360-round) duration. Represented as an offense-focused penalty since the
/// victim still defends when attacked.
/// </summary>
public sealed class AngerSuppression : ISpell
{
    public string Name => "Anger suppression";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => 9;

    public int ManaCost => 17;

    public int PowerBonusPerManaPoint => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 10;

    public int DurationInRounds => 360;

    public int GetDamage() => 0;

    public void OnHit(Attacker caster, Attacker target)
    {
        target.AddTemporaryModifier(new CombatModifier
        {
            AttackValue = -30,
            DefenseValue = 0,
            InitiateValue = -10,
            AimValue = -20
        });
    }
}
