using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Sárga gyertya (Boszorkány — Gyertyamágia, Első Törvénykönyv p.226). Book Mana cost is
/// "whichever Jellemtorzító Átok is infused, plus 5"; 15 is a representative mid-range estimate,
/// and Power similarly represents a mid-range curse's Erősség. Infuses the candle with any of the
/// Jellemtorzító Átkok (character-flaw curses), lasting only while the target stays in the smoke
/// rather than permanently.
/// </summary>
public sealed class YellowCandle : ISpell
{
    public string Name => "Yellow candle";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => 8;

    public int ManaCost => 15;

    public int PowerBonusPerManaPoint => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 10;

    public int DurationInRounds => 30;

    public int GetDamage() => 0;
}
