using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Psi.Disciplines.Slan;

/// <summary>
/// Tetszhalál (Slan-út, p.125). Suspends the body's life processes: no need for food, water, or
/// air, motionless and cold as death, mind shut down (drops the Dinamikus Pszi-pajzs, keeps the
/// Statikus one). The Astral/Mental bodies stay awake, so the user remains vulnerable to
/// Természeti Anyag Mágiája. Duration must be chosen up front and can't be interrupted early. No
/// pain (Fp) can be inflicted, and Ép damage taken is halved. Uniquely regenerative: 1 Ép and 10
/// Fp heal per hour spent this way (never above maximum), and poison already in the body is
/// slowed to a third strength over triple duration. Only detectable via Kyr Auraérzékelés.
/// </summary>
public sealed class SuspendedAnimation : IPsiDiscipline
{
    public string Name => "Suspended animation";

    public int? Power => null;

    public int PsiPointCost => 6;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 100;

    public int DurationInRounds => 360;

    public int GetDamage() => 0;
}
