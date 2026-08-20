using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Szivárványszín gyertya (Boszorkány — Gyertyamágia, Első Törvénykönyv p.227). Combines multiple
/// other candle-magic layers into one candle, each keeping its own cost/strength/duration/
/// resistance; 1 is a nominal placeholder cost, not a real one — this is a flavor-only catalog
/// entry representing the base multi-layer candle concept.
/// </summary>
public sealed class RainbowCandle : ISpell
{
    public string Name => "Rainbow candle";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => null;

    public int ManaCost => 1;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 10;

    public int DurationInRounds => 30;

    public int GetDamage() => 0;
}
