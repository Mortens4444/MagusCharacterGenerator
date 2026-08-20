using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Psi.Disciplines.General;

/// <summary>
/// Dinamikus Pszi-pajzs (Általános Diszciplína, p.121-122). A second protective layer stacked on
/// top of a Statikus Pajzs; takes 30 rounds to first raise, after which points can be freely
/// added/withdrawn with 1 round of light concentration each time. Its stored points count toward
/// the user's current Psi points and can be spent on other disciplines. Drops instantly if the
/// user is knocked out, stunned, or loses consciousness for any reason; can't be built around
/// someone else's mind. Adjusts Character.DynamicAstralPsiShield/DynamicMentalPsiShield rather
/// than resolving as a combat effect — a flavor-only catalog entry, not wired into the
/// enemy-targeting combat pipeline.
/// </summary>
public sealed class DynamicPsiShield : IPsiDiscipline
{
    public string Name => "Dynamic psi shield";

    public int? Power => null;

    public int PsiPointCost => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 300;

    public int DurationInRounds => 3600;

    public int GetDamage() => 0;
}
