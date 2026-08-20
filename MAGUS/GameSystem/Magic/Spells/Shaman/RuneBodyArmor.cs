using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Shaman;

/// <summary>
/// Testpáncél (Sámán — Állatszellem idézés, Második Törvénykönyv p.131-132). Turtle-blood sigils
/// painted across the body toughen the recipient's skin into thin, hard armor granting SFÉ equal
/// to the shaman's Tapasztalati Szint (max 8), at the cost of MGT 3 (until an early Ügyesség check
/// lets them adjust) and treating the skin itself as MGT-3 material. This codebase has no
/// armor/SFÉ (damage-reduction) subsystem for spell-granted armor; this class exists only as a
/// spellbook/catalog entry with no simulated mechanical effect.
/// </summary>
public sealed class RuneBodyArmor : ISpell
{
    public string Name => "Rune body armor";

    public MagicSchool School => MagicSchool.Shaman;

    public int? Power => null;

    public int ManaCost => 10;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 10;

    public int DurationInRounds => 3;

    public int GetDamage() => 0;
}
