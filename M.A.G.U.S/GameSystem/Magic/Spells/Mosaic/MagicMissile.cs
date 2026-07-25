using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Interfaces;

namespace M.A.G.U.S.GameSystem.Magic.Spells.Mosaic;

public sealed class MagicMissile : ISpell
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Magic missile";

    public MagicSchool School => MagicSchool.Mosaic;

    public int InitiateValue => 30;

    public int ManaCost => 3;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 1;

    public int DurationInRounds => 1;

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(1)]
    public int GetDamage() => diceThrow._1D6() + 1;
}
