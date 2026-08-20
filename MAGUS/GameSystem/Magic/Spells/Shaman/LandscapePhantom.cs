using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Shaman;

/// <summary>
/// Illúzió (Sámán — Természeti mágia, Második Törvénykönyv p.129). A rare, semi-mythical
/// shamanic art: raises a towering illusory backdrop that reshapes how an entire region appears to
/// look, limited to plausible natural scenery (no sky, weather or sun tricks). This codebase has no
/// large-scale illusion subsystem; this class exists only as a spellbook/catalog entry with no
/// simulated mechanical effect.
/// </summary>
public sealed class LandscapePhantom : ISpell
{
    public string Name => "Landscape phantom";

    public MagicSchool School => MagicSchool.Shaman;

    public int? Power => null;

    public int ManaCost => 33;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 170;

    public int DurationInRounds => 360;

    public int GetDamage() => 0;
}
