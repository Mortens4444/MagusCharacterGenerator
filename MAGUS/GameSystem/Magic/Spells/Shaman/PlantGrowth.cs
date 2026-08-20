using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Shaman;

/// <summary>
/// Növesztés (Sámán — Természeti mágia, Második Törvénykönyv p.127-130). Rushes a plant's growth
/// to full maturity in moments (a sapling can fruit within a single casting); cost scales by target
/// size (1 Mp for grass up to 28 Mp for a full tree, each +1 FP) - the smallest tier (1 Mp + 1 FP)
/// is used here. This codebase has no plant-growth subsystem; this class exists only as a spellbook/catalog entry
/// with no simulated mechanical effect.
/// </summary>
public sealed class PlantGrowth : ISpell
{
    public string Name => "Plant growth";

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
