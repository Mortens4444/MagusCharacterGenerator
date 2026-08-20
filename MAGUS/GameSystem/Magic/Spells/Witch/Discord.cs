using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Viszály (Boszorkány — Asztrálmágia, Első Törvénykönyv p.209). Sows discord among a group within
/// range, potentially escalating to blows. Duration is "5 perc/szint" in the book; level-1 baseline
/// shown, not level-scaled.
/// </summary>
public sealed class Discord : ISpell
{
    public string Name => "Discord";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => 5;

    public int ManaCost => 14;

    public int PowerBonusPerManaPoint => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 5;

    public int DurationInRounds => 30;

    public int GetDamage() => 0;
}
