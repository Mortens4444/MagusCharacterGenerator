using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Bard;

/// <summary>
/// Nyelvzagyválás (Bárd — Hangmágia, Első Törvénykönyv p.137). Makes the target's words come out
/// in a different, constantly-shifting language each word, making communication impossible.
/// Duration is perc/szint in the book; level-1 baseline (1 perc = 6 rounds) shown, not
/// level-scaled.
/// </summary>
public sealed class LanguageScramble : ISpell
{
    public string Name => "Language scramble";

    public MagicSchool School => MagicSchool.Bard;

    public int? Power => null;

    public int ManaCost => 6;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 1;

    public int DurationInRounds => 6;

    public int GetDamage() => 0;
}
