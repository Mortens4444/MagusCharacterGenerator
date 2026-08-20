using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Shaman;

/// <summary>
/// Szolga (Sámán — Természeti mágia, Második Törvénykönyv p.126-127). A spirit moves into a chosen
/// plant, which then obeys up to 5 stored one-word commands ("guard", "follow", "attack", ...) for
/// the duration; cost scales with the plant's size (7 Mp for anything smaller than a bush, up to
/// 30 Mp for a tree) - the smallest tier is used here. This codebase has no
/// animated-plant-servant subsystem; this class exists only as a spellbook/catalog entry with no
/// simulated mechanical effect.
/// </summary>
public sealed class PlantServant : ISpell
{
    public string Name => "Plant servant";

    public MagicSchool School => MagicSchool.Shaman;

    public int? Power => null;

    public int ManaCost => 7;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 30;

    public int DurationInRounds => 60480;

    public int GetDamage() => 0;
}
