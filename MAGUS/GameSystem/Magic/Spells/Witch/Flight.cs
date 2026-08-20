using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Repülés (Boszorkány — Misztikus képesség, Első Törvénykönyv p.203). Lets the witch fly under
/// her own power, carrying a modest amount of gear, up to roughly 50-60 mérföld/h. Duration is 15
/// perc/szint; level-1 baseline shown, not level-scaled.
/// </summary>
public sealed class Flight : ISpell
{
    public string Name => "Flight";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => null;

    public int ManaCost => 35;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 10;

    public int DurationInRounds => 90;

    public int GetDamage() => 0;
}
