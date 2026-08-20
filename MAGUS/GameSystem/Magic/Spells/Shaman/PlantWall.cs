using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Shaman;

/// <summary>
/// Növényfal (Sámán — Természeti mágia, Második Törvénykönyv p.126). Weaves living trees, bushes
/// and undergrowth within 100 meters into an impassable wall (1-1.5 meters thick, any shape the
/// shaman chooses, 3 meters long per Tapasztalati Szint) - useful to block roads, hide structures
/// or pen in creatures. This codebase has no terrain/obstacle subsystem; this class exists only as
/// a spellbook/catalog entry with no simulated mechanical effect.
/// </summary>
public sealed class PlantWall : ISpell
{
    public string Name => "Plant wall";

    public MagicSchool School => MagicSchool.Shaman;

    public int? Power => null;

    public int ManaCost => 14;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 20;

    public int DurationInRounds => 8640;

    public int GetDamage() => 0;
}
