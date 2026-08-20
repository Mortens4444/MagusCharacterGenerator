using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Shaman;

/// <summary>
/// Vízmérgezés (Sámán, Második Törvénykönyv p.112, Ráolvasások — Területre ható átkok). Poisons a
/// well or small body of still water, turning it briefly murky yellow-green; anyone or anything
/// that drinks it risks a magical illness, and the thirst it induces tends to make victims drink
/// again despite knowing it's tainted. Book duration is "Maradandó" (lasting); approximated here as
/// a long but finite value. This codebase has no water-contamination/drinking-hazard subsystem;
/// this class exists only as a spellbook/catalog entry with no simulated mechanical effect.
/// </summary>
public sealed class WaterPoisoning : ISpell
{
    public string Name => "Water poisoning";

    public MagicSchool School => MagicSchool.Shaman;

    public int? Power => null;

    public int ManaCost => 43;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 420;

    public int DurationInRounds => 3600;

    public int GetDamage() => 0;
}
