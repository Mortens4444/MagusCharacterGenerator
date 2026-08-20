using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Shaman;

/// <summary>
/// Összeforrás - tudatilag (Sámán — Szabad mágia, Második Törvénykönyv p.122-123). Links two or
/// more consenting shamans' Astral and Mental defenses into one shared, pooled ward, and lets a
/// higher-level participant's stronger spells support the others. Cost/time scale per extra
/// participant (35 Mp + 1 FP per 2 people, +30 Mp per further person); baseline 2-person cost
/// shown here, per-person scaling not modeled. This codebase has no shared-defense-pool subsystem;
/// this class exists only as a spellbook/catalog entry with no simulated mechanical effect.
/// </summary>
public sealed class MindMerge : ISpell
{
    public string Name => "Mind merge";

    public MagicSchool School => MagicSchool.Shaman;

    public int? Power => null;

    public int ManaCost => 35;

    public int PainTolerancePointCost => 1;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Mental;

    public int CastingTimeInSegments => 60;

    public int DurationInRounds => 720;

    public int GetDamage() => 0;
}
