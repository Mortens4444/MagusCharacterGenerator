using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Psi.Disciplines.Slan;

/// <summary>
/// Statikus Pszi-pajzs (Slan-út, p.125). Works exactly like the General Statikus Pszi-pajzs
/// (see `MAGUS.GameSystem.Psi.Disciplines.General.StaticPsiShield`) in effect, but a Slan's
/// version can never be torn down by anyone else's Psi-ostrom — only the Slan who built it can
/// dismantle or rebuild it, and only around their own mind (never someone else's). Named
/// `SlanStaticPsiShield` to avoid colliding with the General discipline class of a similar name.
/// Raises Character.StaticAstralPsiShield/StaticMentalPsiShield rather than resolving as a combat
/// effect — a flavor-only catalog entry, not wired into the enemy-targeting combat pipeline.
/// </summary>
public sealed class SlanStaticPsiShield : IPsiDiscipline
{
    public string Name => "Static psi shield (Slan)";

    public int? Power => null;

    public int PsiPointCost => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 900;

    public int DurationInRounds => 3600;

    public int GetDamage() => 0;
}
