using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Shaman;

/// <summary>
/// Esőtánc (Sámán — Természeti mágia, Második Törvénykönyv p.126). Calls rain (or snow, in cold
/// climates) from the clouds over a chosen area, useful for ending droughts but capable of flooding
/// rivers and settlements if abused; the shaman can cancel it early. This codebase has no
/// weather/agriculture subsystem; this class exists only as a spellbook/catalog entry with no
/// simulated mechanical effect.
/// </summary>
public sealed class RainDance : ISpell
{
    public string Name => "Rain dance";

    public MagicSchool School => MagicSchool.Shaman;

    public int? Power => null;

    public int ManaCost => 18;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 210;

    public int DurationInRounds => 360;

    public int GetDamage() => 0;
}
