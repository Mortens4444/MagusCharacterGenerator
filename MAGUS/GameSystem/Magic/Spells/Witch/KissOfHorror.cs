using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Iszonyat csókja (Boszorkány — Csókmágia, Első Törvénykönyv p.223-224). Instills paralyzing
/// terror of the witch specifically — the victim can't bring themselves to harm her, and talks
/// others out of trying too — until the duration ends, when the fear curdles into hatred instead.
/// Book duration is "1 nap (vagy lásd Csókmágia)" — the base 1-day figure is shown; the extension
/// clause isn't modeled.
/// </summary>
public sealed class KissOfHorror : ISpell
{
    public string Name => "Kiss of horror";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => 10;

    public int ManaCost => 23;

    public int PowerBonusPerManaPoint => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 5;

    public int DurationInRounds => 8640;

    public int GetDamage() => 0;
}
