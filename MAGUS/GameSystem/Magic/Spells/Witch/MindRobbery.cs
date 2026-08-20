using MAGUS.Enums;
using MAGUS.GameSystem.CombatModifiers;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Tudatrablás (Boszorkány — Mentálmágia, Első Törvénykönyv p.217). Strips the target of
/// conscious thought, turning them into an instinct-driven animal (no speech, no magic) on a
/// failed Mental resistance roll. Duration is level-difference-based (1 hour per level
/// difference, or 1 minute if the target is equal/higher level); level-1 baseline (6 rounds = 1
/// minute) shown, not level-scaled. Represented as a combat penalty rather than a true feral-AI
/// state.
/// </summary>
public sealed class MindRobbery : ISpell
{
    private const int Penalty = -20;

    public string Name => "Mind robbery";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => 8;

    public int ManaCost => 30;

    public int PowerBonusPerManaPoint => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Mental;

    public int CastingTimeInSegments => 2;

    public int DurationInRounds => 6;

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
