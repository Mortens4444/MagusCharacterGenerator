using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Shaman;

/// <summary>
/// Napmaszk (Sámán — Maszkmágia, Második Törvénykönyv p.135-136). An oakwood mask painted with
/// plant dyes, depicting a face haloed like the sun. Once empowered (55 Mp + 5 FP per the book's
/// stat block; recharging the mask itself afterward costs a separate 38 Mp + 1 FP "Felruházás",
/// not modeled), it fully cures one condition on a touched patient - a wound, a disease or a
/// poisoning - combining the effect of Forrasztás, Kovácsolás, Betegségelhárítás and Méregtelenítés
/// in one working, though a patient suffering several conditions at once still needs one use per
/// condition. This codebase has no wound/disease/poison-curing subsystem; this class exists only
/// as a spellbook/catalog entry with no simulated mechanical effect.
/// </summary>
public sealed class SunMask : ISpell
{
    public string Name => "Sun mask";

    public MagicSchool School => MagicSchool.Shaman;

    public int? Power => null;

    public int ManaCost => 55;

    public int PainTolerancePointCost => 5;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 10;

    public int DurationInRounds => 3600;

    public int GetDamage() => 0;
}
