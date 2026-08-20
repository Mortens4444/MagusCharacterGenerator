using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Igaz felelet (Boszorkány — Asztrálmágia, Első Törvénykönyv p.209-210). Compels the target to
/// answer one of the witch's questions truthfully, as long as the witch stays within 3 láb. Book
/// duration is "15 perc + special"; the "+special" extension isn't modeled.
/// </summary>
public sealed class TrueAnswer : ISpell
{
    public string Name => "True answer";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => 3;

    public int ManaCost => 5;

    public int PowerBonusPerManaPoint => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 10;

    public int DurationInRounds => 90;

    public int GetDamage() => 0;
}
