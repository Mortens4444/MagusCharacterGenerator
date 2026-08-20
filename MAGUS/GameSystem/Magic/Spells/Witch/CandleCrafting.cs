using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Gyertyakészítés (Boszorkány — Gyertyamágia, Első Törvénykönyv p.226-227). Book Mana cost
/// varies entirely by which candle spell is being infused into the candle; 1 is a nominal
/// placeholder, not a real cost. Casting time is 1 óra (3600 segments); the crafted candle
/// remains usable indefinitely until lit.
/// </summary>
public sealed class CandleCrafting : ISpell
{
    public string Name => "Candle crafting";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => null;

    public int ManaCost => 1;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 3600;

    public int DurationInRounds => 3600;

    public int GetDamage() => 0;
}
