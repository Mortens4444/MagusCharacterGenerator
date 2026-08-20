using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Szószátyárság (Boszorkány — Átkok, Első Törvénykönyv p.215). A Jellemtorzító Átok
/// (character-flaw curse) that turns the target into a nonstop chatterer, on a failed Astral
/// resistance roll.
/// </summary>
public sealed class InflictGarrulousness : ISpell
{
    public string Name => "Inflict garrulousness";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => 8;

    public int ManaCost => 8;

    public int PowerBonusPerManaPoint => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 50;

    public int DurationInRounds => 3600;

    public int GetDamage() => 0;
}
