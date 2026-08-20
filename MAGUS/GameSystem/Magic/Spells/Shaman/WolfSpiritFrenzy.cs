using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Shaman;

/// <summary>
/// Ordas (Sámán — Állatszellem idézés, Második Törvénykönyv p.131-132). A wolf-blood sigil raises
/// the recipient's Állóképesség to 20 (never lowering it) and lets them fight on past FP loss until
/// death instead of collapsing; onlookers who fail an Astral check fight under Fear. Carries a real
/// risk of lycanthropy with repeated use. This codebase has no death's-door-combat/lycanthropy
/// subsystem; this class exists only as a spellbook/catalog entry with no simulated mechanical
/// effect.
/// </summary>
public sealed class WolfSpiritFrenzy : ISpell
{
    public string Name => "Wolf spirit frenzy";

    public MagicSchool School => MagicSchool.Shaman;

    public int? Power => null;

    public int ManaCost => 14;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 310;

    public int DurationInRounds => 18;

    public int GetDamage() => 0;
}
