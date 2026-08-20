using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Rabszolgaság csókja (Boszorkány — Csókmágia, Első Törvénykönyv p.223). Forces total obedience
/// to the witch's commands for the duration. Book duration is "1 nap (vagy lásd Csókmágia)" — the
/// base 1-day figure is shown; the extension clause isn't modeled.
/// </summary>
public sealed class KissOfEnslavement : ISpell
{
    public string Name => "Kiss of enslavement";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => 10;

    public int ManaCost => 35;

    public int PowerBonusPerManaPoint => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Mental;

    public int CastingTimeInSegments => 5;

    public int DurationInRounds => 8640;

    public int GetDamage() => 0;
}
