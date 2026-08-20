using MAGUS.Enums;
using MAGUS.GameSystem.CombatModifiers;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Bard;

/// <summary>
/// Félelem dala (Bárd — Dalmágia, Első Törvénykönyv p.135). Instils dread in the bard's enemies
/// (allies are unaffected); anyone who hears the song and fails their resistance flees the source
/// immediately. Duration lasts as long as the bard keeps singing; approximated as a flat 6
/// rounds. Represents fleeing in terror as a heavy combat-value penalty.
/// </summary>
public sealed class FearSong : ISpell
{
    private const int Penalty = 35;

    public string Name => "Fear song";

    public MagicSchool School => MagicSchool.Bard;

    public int? Power => 6;

    public int ManaCost => 4;

    public int PowerBonusPerManaPoint => 1;

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
