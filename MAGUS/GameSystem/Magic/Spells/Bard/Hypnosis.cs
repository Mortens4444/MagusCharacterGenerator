using MAGUS.Enums;
using MAGUS.GameSystem.CombatModifiers;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Bard;

/// <summary>
/// Hipnózis (Bárd — Egyéb bárdmágiák, Első Törvénykönyv p.149, Type: Asztrál+Fénymágia). A
/// glowing orb lulls the target into sleep or a hypnotic trance in which they must obey the
/// bard's commands. Duration is perc/szint in the book; level-1 baseline shown, not
/// level-scaled. Represented as a large combat-value penalty on hit, mirroring
/// Priest/Punishment.cs, since Attacker has no dedicated sleep/hypnosis status.
/// </summary>
public sealed class Hypnosis : ISpell
{
    private const int Penalty = 50;

    public string Name => "Hypnosis";

    public MagicSchool School => MagicSchool.Bard;

    public int? Power => 6;

    public int ManaCost => 20;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 60;

    public int DurationInRounds => 6;

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
