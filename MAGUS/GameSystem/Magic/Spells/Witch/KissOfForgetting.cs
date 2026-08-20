using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Felejtés csókja (Boszorkány — Csókmágia, Első Törvénykönyv p.223). Erases a single chosen
/// memory/episode from the victim for the duration. Book duration is "1 nap (vagy lásd
/// Csókmágia)" — the base 1-day figure is shown; the extension clause (how the kiss landed can
/// stretch this to a week, a month, or permanent) isn't modeled.
/// </summary>
public sealed class KissOfForgetting : ISpell
{
    public string Name => "Kiss of forgetting";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => 10;

    public int ManaCost => 18;

    public int PowerBonusPerManaPoint => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Mental;

    public int CastingTimeInSegments => 5;

    public int DurationInRounds => 8640;

    public int GetDamage() => 0;
}
