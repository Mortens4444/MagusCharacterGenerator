using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Shaman;

/// <summary>
/// Sasszem (Sámán — Állatszellem idézés, Második Törvénykönyv p.132). A sighted-animal-blood sigil
/// (hawk, eagle, wolf, ...) drawn around the recipient's eyes sharpens their sight to roughly
/// triple normal range (sixfold for plains-raised nomads), per the M.A.G.U.S. Fényviszonyok table,
/// and grants +10 Astral resistance plus doubled chance to see through mirages and other
/// illusion-based invisibility. This codebase has no perception-range/illusion-detection
/// subsystem; this class exists only as a spellbook/catalog entry with no simulated mechanical
/// effect.
/// </summary>
public sealed class EagleEyeSense : ISpell
{
    public string Name => "Eagle eye sense";

    public MagicSchool School => MagicSchool.Shaman;

    public int? Power => null;

    public int ManaCost => 4;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 130;

    public int DurationInRounds => 3;

    public int GetDamage() => 0;
}
