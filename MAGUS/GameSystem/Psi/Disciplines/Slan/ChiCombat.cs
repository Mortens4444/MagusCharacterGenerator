using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Psi.Disciplines.Slan;

/// <summary>
/// Chi-harc (Slan-út, p.123-124). Channels inner Psi energy into the martial/sword artist's own
/// strikes, making a bare hand as sharp as a blade. Scales with Experience Level per a fixed table
/// (level 1: +10 TÉ/+2 VÉ,KÉ/+1 Sp for 1 Psi point and 1 round; up to level 19+: +50 TÉ/+18
/// VÉ,KÉ/+19 Sp, with further levels adding only +1 Sp each). Extra Psi points only extend the
/// duration, never the bonuses. Requires an equal number of "recovery" rounds afterward doing only
/// normal combat. Self-only combat buff; the level-scaling table isn't modeled — this is a
/// flavor-only catalog entry representing the level-1 baseline.
/// </summary>
public sealed class ChiCombat : IPsiDiscipline
{
    public string Name => "Chi combat";

    public int? Power => null;

    public int PsiPointCost => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 1;

    public int DurationInRounds => 1;

    public int GetDamage() => 0;
}
