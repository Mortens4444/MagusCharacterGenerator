using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Bard;

/// <summary>
/// Hangidézés (Bárd — Hangmágia, Első Törvénykönyv p.139). Replays the sounds of a past event
/// the bard personally heard, straight from memory. Duration is 2 perc/szint in the book;
/// level-1 baseline shown, not level-scaled.
/// </summary>
public sealed class SoundRecall : ISpell
{
    public string Name => "Sound recall";

    public MagicSchool School => MagicSchool.Bard;

    public int? Power => null;

    public int ManaCost => 8;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 50;

    public int DurationInRounds => 12;

    public int GetDamage() => 0;
}
