using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Shaman;

/// <summary>
/// Szél (Sámán — Természeti mágia, Második Törvénykönyv p.126). Raises a weak, fully
/// shaman-directed breeze (even indoors, given some existing draft) - enough to snuff candles and
/// torches, fan or spread open flames, and kick up dust to temporarily blind people. Requires no
/// concentration once started. This codebase has no wind/blinding subsystem; this class exists
/// only as a spellbook/catalog entry with no simulated mechanical effect.
/// </summary>
public sealed class WindGust : ISpell
{
    public string Name => "Wind gust";

    public MagicSchool School => MagicSchool.Shaman;

    public int? Power => null;

    public int ManaCost => 3;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 4;

    public int DurationInRounds => 12;

    public int GetDamage() => 0;
}
