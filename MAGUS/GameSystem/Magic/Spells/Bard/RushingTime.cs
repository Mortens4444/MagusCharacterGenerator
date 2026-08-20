using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Bard;

/// <summary>
/// Rohanó idő (Bárd — Egyéb bárdmágiák, Első Törvénykönyv p.149, Type: Fény+Hangmágia). Makes
/// time appear to race by around the victims (plants visibly growing, dust settling in seconds).
/// Duration is perc/szint in the book; level-1 baseline shown, not level-scaled. Purely a
/// perceptual illusion; no combat mechanic modeled.
/// </summary>
public sealed class RushingTime : ISpell
{
    public string Name => "Rushing time";

    public MagicSchool School => MagicSchool.Bard;

    public int? Power => null;

    public int ManaCost => 34;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 10;

    public int DurationInRounds => 6;

    public int GetDamage() => 0;
}
