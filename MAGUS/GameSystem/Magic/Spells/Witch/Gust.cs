using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Fuvallat (Boszorkány — Elemi Mágia, Első Törvénykönyv p.208). A weak wind, even indoors,
/// strong enough to snuff out candle and torch flames.
/// </summary>
public sealed class Gust : ISpell
{
    public string Name => "Gust";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => null;

    public int ManaCost => 6;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 2;

    public int DurationInRounds => 1;

    public int GetDamage() => 0;
}
