using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Shields;

public class SmallShield : Shield
{
    public override double AttacksPerRound => 1;

    public int InitiateValue => 1;

    public int DefenseValue => 20;

    public int MovementObstructiveFactor => 0;

    public override double Weight => 1;

    public override Money Price => new(0, 6);

    [DiceThrow(ThrowType._1D6)]
    public override int GetDamage() => DiceThrow._1D6();

    public override string Name => "Small shield";

    public override string Description => "A light, round buckler or tightly curved shield, small enough to be worn on the forearm. It is used not for broad coverage, but for parrying incoming blows and deflecting arrows, granting the wielder great agility.";
}