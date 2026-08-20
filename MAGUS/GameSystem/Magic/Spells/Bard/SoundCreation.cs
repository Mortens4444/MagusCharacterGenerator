using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Bard;

/// <summary>
/// Hangteremtés (Bárd — Hangmágia, Első Törvénykönyv p.139). Emits any chosen sound (the bard's
/// own voice, another language, an animal noise) from an arbitrary point within range, no louder
/// than a shout. Duration is 5 perc/szint in the book; level-1 baseline shown, not level-scaled.
/// </summary>
public sealed class SoundCreation : ISpell
{
    public string Name => "Sound creation";

    public MagicSchool School => MagicSchool.Bard;

    public int? Power => null;

    public int ManaCost => 2;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 1;

    public int DurationInRounds => 30;

    public int GetDamage() => 0;
}
