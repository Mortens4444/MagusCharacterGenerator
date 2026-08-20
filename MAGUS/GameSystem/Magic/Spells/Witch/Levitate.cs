using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Lebegés (Boszorkány — Alapvarázslatok, Type: Elemi Mágia, Első Törvénykönyv p.202). Lets the
/// witch (or anyone she touches) rise and glide just above the ground or water, moving
/// horizontally at a walking pace. Duration is perc/szint; level-1 baseline shown, not
/// level-scaled.
/// </summary>
public sealed class Levitate : ISpell
{
    public string Name => "Levitate";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => null;

    public int ManaCost => 5;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 3;

    public int DurationInRounds => 6;

    public int GetDamage() => 0;
}
