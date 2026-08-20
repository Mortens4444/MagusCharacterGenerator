using MAGUS.Enums;
using MAGUS.GameSystem.CombatModifiers;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Átokvarázs (Boszorkány — Átkok, Első Törvénykönyv p.213). Curses a target's emotions in a
/// general way (e.g. never feeling a named emotion again, or feeling it constantly toward
/// everyone) on a failed Astral resistance roll. Not to be confused with the unrelated Warlock
/// CurseSpell class of the same Hungarian name (Átokvarázs) — this is the Witch's own version,
/// deliberately renamed to avoid a class-name collision. Book duration is 1 month, extendable;
/// approximated as a long but finite value.
/// </summary>
public sealed class CurseSpellWitch : ISpell
{
    private const int Penalty = -15;

    public string Name => "Curse spell (witch)";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => 10;

    public int ManaCost => 25;

    public int PowerBonusPerManaPoint => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 4;

    public int DurationInRounds => 3600;

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
