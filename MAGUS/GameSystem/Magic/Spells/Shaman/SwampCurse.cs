using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Shaman;

/// <summary>
/// Mocsár (Sámán, Második Törvénykönyv p.111, Ráolvasások — Területre ható átkok). Turns any
/// terrain into a sucking swamp in moments; anyone straying near the center risks being slowly
/// swallowed by the muck and drowned, rescuable only by a thrown rope within 9 rounds. Book
/// duration is "Maradandó" (lasting); approximated here as a long but finite value. This codebase
/// has no terrain-hazard/environmental-drowning subsystem (mirrors Warlock's SwampOfDecay
/// treatment of a similar area curse); this class exists only as a spellbook/catalog entry with no
/// simulated mechanical effect.
/// </summary>
public sealed class SwampCurse : ISpell
{
    public string Name => "Swamp curse";

    public MagicSchool School => MagicSchool.Shaman;

    public int? Power => null;

    public int ManaCost => 62;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 420;

    public int DurationInRounds => 3600;

    public int GetDamage() => 0;
}
