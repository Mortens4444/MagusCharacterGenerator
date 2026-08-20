using MAGUS.Enums;
using MAGUS.GameSystem.CombatModifiers;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Álom varázs (Boszorkány — Lélekvarázs, Első Törvénykönyv p.219-220). Dual Asztrális+Mentális
/// resistance in the book, Astral modeled here. Lulls up to (caster level) humanoids within 10
/// láb into unwakeable natural sleep for the first 15 minutes (90 rounds); represented as a heavy
/// combat-value penalty since Attacker has no true unconscious/asleep flag. Named
/// SleepSpellWitch (not SleepSong) to avoid colliding with the unrelated Bard-school spell.
/// </summary>
public sealed class SleepSpellWitch : ISpell
{
    private const int Penalty = 50;

    public string Name => "Sleep spell";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => 8;

    public int ManaCost => 18;

    public int PowerBonusPerManaPoint => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 10;

    public int DurationInRounds => 90;

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
