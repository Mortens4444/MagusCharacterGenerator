using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Warlock;

/// <summary>
/// Bebörtönzés (Boszorkánymester — Villámmágia, Első Törvénykönyv p.243). Traps a human-sized
/// or smaller creature in a 1-láb-radius cage of raw, lightning-like energy; damage is only
/// dealt if the prisoner touches or crosses the bars. Duration is óra/szint in the book;
/// level-1 baseline shown, not level-scaled.
/// </summary>
public sealed class EnergyImprisonment : ISpell
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Energy imprisonment";

    public MagicSchool School => MagicSchool.Warlock;

    public int? Power => null;

    public int ManaCost => 45;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 60;

    public int DurationInRounds => 360;

    [DiceThrow(ThrowType._7D10)]
    public int GetDamage() => diceThrow._7D10();
}
