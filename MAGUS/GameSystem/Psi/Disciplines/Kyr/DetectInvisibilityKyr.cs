using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Psi.Disciplines.Kyr;

/// <summary>
/// Láthatatlanság Észlelése (Kyr metódus, p.127). For 5 rounds, lets the wizard see magically
/// invisible creatures/objects and Leplezés-hidden magical effects, but only those whose
/// invisibility strength (E) is lower than this discipline's own strength (base 1, doubling or
/// tripling the Psi points spent multiplies the strength and duration together without limit).
/// This is the wizard's own perception, not an attack on anyone's mind, so no target ever gets a
/// resistance roll — Power is null, matching every other non-attack discipline in the catalog.
/// Named `DetectInvisibilityKyr` to avoid any future collision with other schools' similarly-named
/// spells.
/// </summary>
public sealed class DetectInvisibilityKyr : IPsiDiscipline
{
    public string Name => "Detect invisibility (Kyr)";

    public int? Power => null;

    public int PsiPointCost => 5;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 2;

    public int DurationInRounds => 5;

    public int GetDamage() => 0;
}
