using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Bard;

/// <summary>
/// Dalegyesítés (Bárd — Hangmágia, Első Törvénykönyv p.136). Combines two song spells into one,
/// so they can both take effect together instead of needing separate rounds. Duration matches
/// the combined songs' own duration; not independently tracked here.
/// </summary>
public sealed class SongMerging : ISpell
{
    public string Name => "Song merging";

    public MagicSchool School => MagicSchool.Bard;

    public int? Power => null;

    public int ManaCost => 18;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 1;

    public int DurationInRounds => 1;

    public int GetDamage() => 0;
}
