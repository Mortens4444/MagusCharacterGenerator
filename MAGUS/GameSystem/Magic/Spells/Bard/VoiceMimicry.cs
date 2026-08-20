using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Bard;

/// <summary>
/// Hangutánzás (Bárd — Hangmágia, Első Törvénykönyv p.138). Projects a studied creature's exact
/// vocal sound (and other noises it makes) from any point within range. Duration is 15
/// perc/szint in the book; level-1 baseline (90 rounds) shown, not level-scaled.
/// </summary>
public sealed class VoiceMimicry : ISpell
{
    public string Name => "Voice mimicry";

    public MagicSchool School => MagicSchool.Bard;

    public int? Power => null;

    public int ManaCost => 4;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 3;

    public int DurationInRounds => 90;

    public int GetDamage() => 0;
}
