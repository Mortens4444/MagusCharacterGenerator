using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Shaman;

/// <summary>
/// Összeforrás - életerővel (Sámán — Szabad mágia, Második Törvénykönyv p.124). Like
/// Összeforrás - tudatilag, but pools Fájdalomtűrés and Életerő instead of mental defenses, letting
/// a wounded participant be topped up instantly from the others' reserves. Cost/time scale per
/// extra participant (35 Mp + 1 FP per 2 people, +30 Mp per further person); baseline 2-person cost
/// shown here. This codebase has no shared-HP-pool subsystem; this class exists only as a
/// spellbook/catalog entry with no simulated mechanical effect.
/// </summary>
public sealed class LifeForceMerge : ISpell
{
    public string Name => "Life force merge";

    public MagicSchool School => MagicSchool.Shaman;

    public int? Power => null;

    public int ManaCost => 35;

    public int PainTolerancePointCost => 1;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 60;

    public int DurationInRounds => 360;

    public int GetDamage() => 0;
}
