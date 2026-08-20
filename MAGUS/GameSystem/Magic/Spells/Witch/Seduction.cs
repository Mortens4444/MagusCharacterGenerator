using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Csábítás (Boszorkány — Bájolás, Első Törvénykönyv p.221). A stronger form of Őrjítő pillantás
/// that drives even shy men into open courtship, and men already drawn to women into an obsessive
/// need to please the witch. Duration is 1 óra/szint in the book; level-1 baseline shown, not
/// level-scaled.
/// </summary>
public sealed class Seduction : ISpell
{
    public string Name => "Seduction";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => 10;

    public int ManaCost => 12;

    public int PowerBonusPerManaPoint => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 1;

    public int DurationInRounds => 360;

    public int GetDamage() => 0;
}
