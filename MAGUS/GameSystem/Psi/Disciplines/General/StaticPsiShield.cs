using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Psi.Disciplines.General;

/// <summary>
/// Statikus Pszi-pajzs (Általános Diszciplína, p.121). Builds a permanent astral or mental shield
/// around the user's own mind (master level: another mind) after 90 rounds of meditation; strength
/// equals the Psi points spent building it, adding to Tudatalatti Mágiaellenállás, and works even
/// while unconscious. Once built it can't be adjusted, only torn down by Psi-ostrom or the builder
/// themself. This raises the character's Character.StaticAstralPsiShield/StaticMentalPsiShield
/// stats rather than resolving as a combat effect, so it's a flavor-only catalog entry here — not
/// wired into the enemy-targeting combat pipeline.
/// </summary>
public sealed class StaticPsiShield : IPsiDiscipline
{
    public string Name => "Static psi shield";

    public int? Power => null;

    public int PsiPointCost => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 900;

    public int DurationInRounds => 3600;

    public int GetDamage() => 0;
}
