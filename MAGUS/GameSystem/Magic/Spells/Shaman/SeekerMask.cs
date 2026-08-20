using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Shaman;

/// <summary>
/// Fürkészmaszk (Sámán — Maszkmágia, Második Törvénykönyv p.136). A pine mask carved as a perfect
/// human face. Once empowered (25 Mp + 7 FP per the book's stat block; recharging the mask itself
/// afterward costs a separate 40 Mp + 1 FP "Felruházás", not modeled), the wearer can read a
/// target's surface thoughts and intentions, or - similarly - relive one remembered moment from the
/// target's past, provided the target fails a Mentális resistance roll against the mask's Erősség.
/// This codebase has no mind-reading/memory-reading subsystem; this class exists only as a
/// spellbook/catalog entry with no simulated mechanical effect.
/// </summary>
public sealed class SeekerMask : ISpell
{
    public string Name => "Seeker mask";

    public MagicSchool School => MagicSchool.Shaman;

    public int? Power => 30;

    public int ManaCost => 25;

    public int PainTolerancePointCost => 7;

    public int PowerBonusPerManaPoint => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Mental;

    public int CastingTimeInSegments => 5;

    public int DurationInRounds => 60;

    public int GetDamage() => 0;
}
