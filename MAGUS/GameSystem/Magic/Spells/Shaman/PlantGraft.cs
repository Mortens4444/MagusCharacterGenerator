using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Shaman;

/// <summary>
/// Átoltás (Sámán — Természeti mágia, Második Törvénykönyv p.130). A simpler cousin of Növesztés:
/// instead of growing the shaman's own plant matter, transforms an existing plant into a different
/// species of similar size, fully viable afterward. Cost scales by target size (1 Mp for grass up
/// to 16 Mp for a tree, each +1 FP) - the smallest tier (1 Mp + 1 FP) is used here. This codebase has no
/// plant-transformation subsystem; this class exists only as a spellbook/catalog entry with no
/// simulated mechanical effect.
/// </summary>
public sealed class PlantGraft : ISpell
{
    public string Name => "Plant graft";

    public MagicSchool School => MagicSchool.Shaman;

    public int? Power => null;

    public int ManaCost => 1;

    public int PainTolerancePointCost => 1;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 10;

    public int DurationInRounds => 3600;

    public int GetDamage() => 0;
}
