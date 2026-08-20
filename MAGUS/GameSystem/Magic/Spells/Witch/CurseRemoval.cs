using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Átokűzés (Boszorkány — Átkok, Első Törvénykönyv p.214). Removes a Witch curse from a target,
/// provided this spell's strength exceeds the curse's own. Book Mana cost scales with the
/// curse's own strength (must exceed it); 2 shown as the base cost. Book duration "maradandó";
/// approximated as a long but finite value. Only removes Witch curses, not Warlock ones.
/// </summary>
public sealed class CurseRemoval : ISpell
{
    public string Name => "Curse removal";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => null;

    public int ManaCost => 2;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 100;

    public int DurationInRounds => 3600;

    public int GetDamage() => 0;
}
