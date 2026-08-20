using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Villámszórás (Boszorkány — Tűzmágia, Első Törvénykönyv p.207). Tiny fire-sparks shoot from the
/// witch's fingertips. Book fires ten tiny 1D3 sparks per round across up to 4 targets; simplified
/// to a single flat 1D6 roll.
/// </summary>
public sealed class SparkShower : ISpell
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Spark shower";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => null;

    public int ManaCost => 9;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 1;

    public int DurationInRounds => 5;

    [DiceThrow(ThrowType._1D6)]
    public int GetDamage() => diceThrow._1D6();
}
