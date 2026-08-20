using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Psi.Disciplines.Slan;

/// <summary>
/// Aranyharang (Slan-út, p.123). Turns the user's own body into living armor, granting a Sebzés
/// Felfogó Érték (damage-soak) equal to the Psi points spent, capped at the user's own Experience
/// Level, for 2 rounds per point (more Psi extends the duration only). Exceeding 3 rounds per
/// level temporarily drains Stamina by the overage for as long the discipline was active. This
/// grants an SFÉ armor value rather than resolving as a direct combat effect ISpell/IPsiDiscipline
/// can represent, so it's a flavor-only self-buff here, not wired into the enemy-targeting
/// combat pipeline.
/// </summary>
public sealed class GoldenBell : IPsiDiscipline
{
    public string Name => "Golden bell";

    public int? Power => null;

    public int PsiPointCost => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 10;

    public int DurationInRounds => 2;

    public int GetDamage() => 0;
}
