using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Tűzgyűrű (Boszorkány — Tűzmágia, Első Törvénykönyv p.205-206). A ring of fire surrounds the
/// witch, burning anyone who crosses it. Book damage shrinks as the ring expands each round
/// (6D6→5D6→4D6→3D6→2D6→1D6 over 6 rounds); simplified to a flat 6D6 (first-round strength).
/// </summary>
public sealed class WitchFireRing : ISpell
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Witch fire ring";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => null;

    public int ManaCost => 32;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 4;

    public int DurationInRounds => 5;

    [DiceThrow(ThrowType._6D6)]
    public int GetDamage() => diceThrow._6D6();
}
