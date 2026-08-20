using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Bard;

/// <summary>
/// Üresség (Bárd — Fénymágia, Első Törvénykönyv p.146). Makes every object in an area (furniture
/// in a room, trees and shrubs in a forest) invisible, leaving only bare surfaces to the eye.
/// Duration is 5 perc/szint in the book; level-1 baseline shown, not level-scaled.
/// </summary>
public sealed class Emptiness : ISpell
{
    public string Name => "Emptiness";

    public MagicSchool School => MagicSchool.Bard;

    public int? Power => null;

    public int ManaCost => 18;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 10;

    public int DurationInRounds => 30;

    public int GetDamage() => 0;
}
