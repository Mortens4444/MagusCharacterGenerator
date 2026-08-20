using MAGUS.Enums;
using MAGUS.GameSystem.CombatModifiers;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Shaman;

/// <summary>
/// Őrület (Sámán, Második Törvénykönyv p.113, Ráolvasások — Tömegre ható átkok). Meant to break
/// large numbers of low-level foes (servants, retainers, rank-and-file soldiers) at once: everyone
/// within range who fails their resistance is possessed by a spirit that unravels their mind into
/// unpredictable rage, terror and grief, lashing out at anyone (including allies) or freezing up
/// entirely, with a 40% chance of a permanent after-effect once the curse ends. Book Erősség is
/// 5 + caster level, book duration 1 week per level; level-1 baselines used (not level-scaled).
/// Book calls for both Asztrális and Mentális resistance; only Mental is representable here, since
/// ISpell has a single ResistanceType. Represented as a heavy penalty to all four combat values,
/// approximating the described "completely unpredictable, may attack anyone" battlefield chaos;
/// the after-effects, dice-roll penalty and NPC-behavior table are not modeled.
/// </summary>
public sealed class MaddeningCurse : ISpell
{
    private const int Penalty = 30;

    public string Name => "Maddening curse";

    public MagicSchool School => MagicSchool.Shaman;

    public int? Power => 5;

    public int ManaCost => 41;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Mental;

    public int CastingTimeInSegments => 6;

    public int DurationInRounds => 60480;

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
