using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Őrjítő pillantás (Boszorkány — Bájolás, Első Törvénykönyv p.221). A single locked glance
/// makes the target unable to stop noticing the witch, drawing them toward starting a
/// conversation. Duration is 1 óra/szint in the book; level-1 baseline shown, not level-scaled.
/// </summary>
public sealed class MaddeningGlance : ISpell
{
    public string Name => "Maddening glance";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => 3;

    public int ManaCost => 5;

    public int PowerBonusPerManaPoint => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 1;

    public int DurationInRounds => 360;

    public int GetDamage() => 0;
}
