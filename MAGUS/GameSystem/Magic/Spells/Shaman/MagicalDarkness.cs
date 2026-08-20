using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Shaman;

/// <summary>
/// Sötétség (Sámán — Természeti mágia, Második Törvénykönyv p.127). Thickens the clouds over a
/// wide area into a dense, oppressive overcast that blots out the sun and turns day into
/// night-like gloom, favoring stealth and unnerving those caught under it. This codebase has no
/// lighting/stealth subsystem; this class exists only as a spellbook/catalog entry with no
/// simulated mechanical effect.
/// </summary>
public sealed class MagicalDarkness : ISpell
{
    public string Name => "Magical darkness";

    public MagicSchool School => MagicSchool.Shaman;

    public int? Power => null;

    public int ManaCost => 27;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 610;

    public int DurationInRounds => 360;

    public int GetDamage() => 0;
}
