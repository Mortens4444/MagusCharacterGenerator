using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Shields;

public class MediumShield : Shield
{
    public double AttacksPerRound => 1;

    public byte InitiatingValue => 0;

    public byte DefendingValue => 35;

    public byte MovementObstructiveFactor => 1;

    public override double Weight => 3;

    public override Money Price => new(1, 6);

    [DiceThrow(ThrowType._1K6)]
    public byte GetDamage() => (byte)DiceThrow._1K6();

    public override string Name => "Medium shield";
}