using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Bard;

/// <summary>
/// Halál dala (Bárd — Dalmágia, Első Törvénykönyv p.136). "The bard's cruellest weapon is the
/// lute" — anyone within 10 láb who hears the song and fails their resistance takes a killing
/// blow to their Astral body, the shock of the soul tearing apart causing outright death.
/// Represents the rulebook's outright death on a failed resistance roll directly, rather than
/// approximating it as a large damage roll. Book duration is "végleges"; approximated as a long
/// but finite value.
/// </summary>
public sealed class DeathSong : ISpell
{
    public string Name => "Death song";

    public MagicSchool School => MagicSchool.Bard;

    public int? Power => 15;

    public int ManaCost => 45;

    public int PowerBonusPerManaPoint => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 10;

    public int DurationInRounds => 3600;

    public int GetDamage() => 0;

    public void OnHit(Attacker caster, Attacker target)
    {
        target.ActualHealthPoints = 0;
    }
}
