using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Bard;

/// <summary>
/// Káosz (Bárd — Fénymágia, Első Törvénykönyv p.147). An unsettling mass illusion (directions
/// swapping, wild light storms, objects rippling) that the book states cannot be disbelieved even
/// by touch. Duration is 1 perc/szint in the book; level-1 baseline shown, not level-scaled. No
/// combat mechanic given beyond unsettling onlookers.
/// </summary>
public sealed class Chaos : ISpell
{
    public string Name => "Chaos";

    public MagicSchool School => MagicSchool.Bard;

    public int? Power => null;

    public int ManaCost => 35;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 10;

    public int DurationInRounds => 60;

    public int GetDamage() => 0;
}
