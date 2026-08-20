using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Psi.Disciplines.General;

/// <summary>
/// Fájdalomcsillapítás (Kínokozás) (Általános Diszciplína, p.119). Restores the user's own Fp
/// 1-for-1 per Psi point spent (never above maximum); doesn't heal or cause real wounds (Ép is
/// never affected). At master level the same mechanism can instead be turned on another creature
/// to inflict Fp loss (Kínokozás) down to unconsciousness. This class models only the alapfok
/// self-heal; not wired into the enemy-targeting combat pipeline, matching how self-buff spells
/// are handled elsewhere (e.g. Fire-school SalamanderSkin).
/// </summary>
public sealed class PainRelief : IPsiDiscipline
{
    public string Name => "Pain relief";

    public int? Power => null;

    public int PsiPointCost => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 10;

    public int DurationInRounds => 3600;

    public int GetDamage() => 0;
}
