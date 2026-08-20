using MAGUS.Enums;
using MAGUS.GameSystem.CombatModifiers;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Shaman;

/// <summary>
/// Szemmelverés (Sámán, Második Törvénykönyv p.114, Ráolvasások — Tömegre ható átkok). A curse
/// feared across nomad tribes: after chanting, the shaman may lock eyes with anyone within 30 m
/// who then resists (book text says Asztrális, the stat block says Mentális — Mental is used here)
/// or has mental demons drain 5 points each from Egészség, Állóképesség, Akaraterő and Asztrál (any
/// hitting zero kills). Since CombatModifier exposes combat values, not ability scores, this is
/// approximated as a flat penalty to all four combat values (mirrors Warlock's InflictAging
/// handling of a similar ability-drain effect). The gaze only takes effect if the shaman actively
/// wills it, is usable for 1 minute per 2 levels after casting, and inflicts despair/aggression
/// and a running dice-roll penalty — none of which is modeled. Book Erősség is 20 + caster level,
/// book duration 1 week per level; level-1 baselines used (not level-scaled).
/// </summary>
public sealed class MalevolentGaze : ISpell
{
    private const int Penalty = 15;

    public string Name => "Malevolent gaze";

    public MagicSchool School => MagicSchool.Shaman;

    public int? Power => 20;

    public int ManaCost => 30;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Mental;

    public int CastingTimeInSegments => 4;

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
