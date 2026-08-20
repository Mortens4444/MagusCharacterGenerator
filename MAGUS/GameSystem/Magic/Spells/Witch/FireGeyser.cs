using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Tűzgejzír (Boszorkány — Tűzmágia, Első Törvénykönyv p.206). Man-high columns of flame erupt
/// from the ground at points the witch designates. Duration is kör/szint; level-1 baseline shown,
/// not level-scaled.
/// </summary>
public sealed class FireGeyser : ISpell
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Fire geyser";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => null;

    public int ManaCost => 26;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 3;

    public int DurationInRounds => 6;

    [DiceThrow(ThrowType._2D6)]
    public int GetDamage() => diceThrow._2D6();
}
