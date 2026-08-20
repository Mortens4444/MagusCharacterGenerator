using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Bard;

/// <summary>
/// Hamis beszéd (Bárd — Hangmágia, Első Törvénykönyv p.138). Silences the target while the bard
/// speaks in their place, apparently from their mouth. Duration is perc/szint in the book;
/// level-1 baseline shown, not level-scaled.
/// </summary>
public sealed class FalseSpeech : ISpell
{
    public string Name => "False speech";

    public MagicSchool School => MagicSchool.Bard;

    public int? Power => null;

    public int ManaCost => 7;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 1;

    public int DurationInRounds => 6;

    public int GetDamage() => 0;
}
