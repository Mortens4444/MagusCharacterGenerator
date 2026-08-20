using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Shaman;

/// <summary>
/// Kopoltyú (Sámán — Állatszellem idézés, Második Törvénykönyv p.131). A fish-blood sigil painted
/// across the chest, neck and lower face lets the recipient breathe and swim underwater like a
/// fish - even one who could barely swim moments before. This codebase has no
/// underwater-breathing/swimming subsystem; this class exists only as a spellbook/catalog entry
/// with no simulated mechanical effect.
/// </summary>
public sealed class Gills : ISpell
{
    public string Name => "Gills";

    public MagicSchool School => MagicSchool.Shaman;

    public int? Power => null;

    public int ManaCost => 23;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 430;

    public int DurationInRounds => 180;

    public int GetDamage() => 0;
}
