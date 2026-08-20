using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Pusztítás (Boszorkány — Misztikus képesség, Első Törvénykönyv p.205). A desperate last-resort
/// spell converting all of the witch's own remaining Mana/Psi/Pain-tolerance points into a
/// variable-strength destructive blast; the self-sacrificial scaling and blast mechanics are too
/// specific to model here, so this is a flavor-only catalog entry.
/// </summary>
public sealed class UtterDestruction : ISpell
{
    public string Name => "Utter destruction";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => null;

    public int ManaCost => 70;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 20;

    public int DurationInRounds => 1;

    public int GetDamage() => 0;
}
