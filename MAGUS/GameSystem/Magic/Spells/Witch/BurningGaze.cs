using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Tüzes tekintet (Boszorkány — Tűzmágia, Első Törvénykönyv p.206). The witch's gaze burns
/// whatever it fixes on. Duration is kör/szint in the book; level-1 baseline shown, not
/// level-scaled.
/// </summary>
public sealed class BurningGaze : ISpell
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Burning gaze";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => null;

    public int ManaCost => 8;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 1;

    public int DurationInRounds => 6;

    [DiceThrow(ThrowType._2D6)]
    public int GetDamage() => diceThrow._2D6();
}
