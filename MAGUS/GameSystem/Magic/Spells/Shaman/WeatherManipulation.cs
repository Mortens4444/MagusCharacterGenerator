using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Shaman;

/// <summary>
/// Időjárás-befolyásolás (Sámán — Természeti mágia, Második Törvénykönyv p.126). Either seizes
/// control of another Természeti mágia weather effect (if this spell's Erősség beats the rival
/// effect's) to weaken, redirect or amplify it, or shapes a plausible-for-the-season weather
/// pattern over a wide area. This codebase has no weather-simulation subsystem; this class exists
/// only as a spellbook/catalog entry with no simulated mechanical effect.
/// </summary>
public sealed class WeatherManipulation : ISpell
{
    public string Name => "Weather manipulation";

    public MagicSchool School => MagicSchool.Shaman;

    public int? Power => null;

    public int ManaCost => 20;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 310;

    public int DurationInRounds => 30;

    public int GetDamage() => 0;
}
