using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Shaman;

/// <summary>
/// Sivárság (Sámán, Második Törvénykönyv p.111, Ráolvasások — Területre ható átkok). Curses an
/// area of land so nutrient uptake fails: plants wither and the soil erodes into barren black
/// dust, unfarmable until a shaman or priest lifts the curse and the ground spends 3 more weeks
/// regenerating. Area is 100 + 10 m per caster level radius, level-1 baseline used (not
/// level-scaled). Book duration is "Maradandó" (lasting); approximated here as a long but finite
/// value. This codebase has no land-fertility/terrain-curse subsystem; this class exists only as a
/// spellbook/catalog entry with no simulated mechanical effect.
/// </summary>
public sealed class BarrenCurse : ISpell
{
    public string Name => "Barren curse";

    public MagicSchool School => MagicSchool.Shaman;

    public int? Power => null;

    public int ManaCost => 45;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 420;

    public int DurationInRounds => 3600;

    public int GetDamage() => 0;
}
