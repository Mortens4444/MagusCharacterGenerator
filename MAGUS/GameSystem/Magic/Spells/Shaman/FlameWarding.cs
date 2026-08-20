using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Shaman;

/// <summary>
/// Tűztagadás (Sámán — Szabad mágia, Második Törvénykönyv p.125). Touch a willing target within a
/// minute of casting to make them immune to fire and heat damage - including hostile fire magic -
/// as long as the attacking flame's strength stays below the ward's Erősség; their gear is not
/// protected. This codebase has no damage-type-immunity subsystem; this class exists only as a
/// spellbook/catalog entry with no simulated mechanical effect.
/// </summary>
public sealed class FlameWarding : ISpell
{
    public string Name => "Flame warding";

    public MagicSchool School => MagicSchool.Shaman;

    public int? Power => null;

    public int ManaCost => 38;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 60;

    public int DurationInRounds => 2;

    public int GetDamage() => 0;
}
