using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Shaman;

/// <summary>
/// Átokfejtés (Sámán, Második Törvénykönyv p.109, Ráolvasások). A Szellemtánc-borne divination
/// that uncovers a curse laid by witches, warlocks, priests or other shamans: the caster's name,
/// caste, rough power, and the curse's true nature and strength. Useful before Átokűzés. Duration
/// is listed as "Egy vizsgálat" (one examination/session) rather than a time span; approximated
/// here as instantaneous. This codebase has no curse/rontás detection subsystem to reveal
/// caster identity or curse metadata; this class exists only as a spellbook/catalog entry with no
/// simulated mechanical effect.
/// </summary>
public sealed class CurseDivination : ISpell
{
    public string Name => "Curse divination";

    public MagicSchool School => MagicSchool.Shaman;

    public int? Power => null;

    public int ManaCost => 8;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 50;

    public int DurationInRounds => 1;

    public int GetDamage() => 0;
}
