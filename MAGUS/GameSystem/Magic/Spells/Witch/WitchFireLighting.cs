using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Tűzgyújtás (Boszorkány — Tűzmágia, Első Törvénykönyv p.205). Ignites all candles, torches and
/// lamps within a 10-láb radius of the witch.
/// </summary>
public sealed class WitchFireLighting : ISpell
{
    public string Name => "Witch fire lighting";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => null;

    public int ManaCost => 3;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 1;

    public int DurationInRounds => 1;

    public int GetDamage() => 0;
}
