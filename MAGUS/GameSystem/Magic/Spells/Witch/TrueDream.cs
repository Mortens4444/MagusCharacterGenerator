using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Igazálom (Boszorkány — Lélekvarázs / Álomellenőrző varázslatok, Első Törvénykönyv p.220). Dual
/// Asztrális+Mentális resistance in the book, Astral modeled here. Affects up to 6 witnesses
/// simultaneously (not modeled as multi-target); 6-hour shared "real" dream adventure.
/// </summary>
public sealed class TrueDream : ISpell
{
    public string Name => "True dream";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => 22;

    public int ManaCost => 62;

    public int PowerBonusPerManaPoint => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 20;

    public int DurationInRounds => 2160;

    public int GetDamage() => 0;
}
