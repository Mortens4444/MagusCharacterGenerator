using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Shaman;

/// <summary>
/// Jóslás (Sámán — Szabad mágia, Második Törvénykönyv p.125). The shaman calls on spirit allies
/// through a divination tool to answer a question, rolling percentile against a Jóslás skill
/// (base 8%/level, +2% per Mana point spent, no upper limit on Mana invested) for a 2d6-keyed
/// answer table ranging from "wait longer" to a plain answer plus bonus hints. The book's cost is
/// "see description" (a percentage-skill spend, not a fixed Mp figure); ManaCost here is a nominal
/// placeholder. This codebase has no skill-percentile/oracle-table subsystem; this class exists
/// only as a spellbook/catalog entry with no simulated mechanical effect.
/// </summary>
public sealed class SpiritDivination : ISpell
{
    public string Name => "Spirit divination";

    public MagicSchool School => MagicSchool.Shaman;

    public int? Power => null;

    public int ManaCost => 1;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 310;

    public int DurationInRounds => 1;

    public int GetDamage() => 0;
}
