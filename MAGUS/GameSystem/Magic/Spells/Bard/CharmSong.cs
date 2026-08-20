using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Bard;

/// <summary>
/// Bájolás dala (Bárd — Dalmágia, Első Törvénykönyv p.135). Anyone within 10 láb who hears the
/// song and fails their resistance becomes friendly toward the bard, following and helping them
/// (the effect breaks if the bard attacks them). No ally/friendly-NPC state exists in this
/// codebase to represent that, so it's flavor-only here.
/// </summary>
public sealed class CharmSong : ISpell
{
    public string Name => "Charm song";

    public MagicSchool School => MagicSchool.Bard;

    public int? Power => 6;

    public int ManaCost => 5;

    public int PowerBonusPerManaPoint => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 60;

    public int DurationInRounds => 720;

    public int GetDamage() => 0;
}
