using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Zöld gyertya (Boszorkány — Gyertyamágia, Első Törvénykönyv p.226-227). Book resistance is
/// Méregellenállás, a poison save, not modeled here — hence Power is null. Delivers a poison gas
/// version of any poison through the candle's smoke; the poison's own effect isn't modeled.
/// </summary>
public sealed class GreenCandle : ISpell
{
    public string Name => "Green candle";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => null;

    public int ManaCost => 26;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 1;

    public int DurationInRounds => 30;

    public int GetDamage() => 0;
}
