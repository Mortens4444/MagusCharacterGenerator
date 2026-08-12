using MAGUS.Enums;
using MAGUS.GameSystem;
using MAGUS.GameSystem.Attributes;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.Shields;

public class SmallShield : Shield
{
    public override double AttacksPerRound => 1;

    public override int InitiateValue => 1;

    public override int DefenseValue => 20;

    public override int MovementObstructiveFactor => 0;

    public override double Weight => 1;

    public override Money Price => new(0, 6);

    [DiceThrow(ThrowType._1D6)]
    public override int GetDamage() => DiceThrow._1D6();

    public override string Name => "Small shield";

    public override string Description => "A light, round buckler or tightly curved shield, small enough to be worn on the forearm. It is used not for broad coverage, but for parrying incoming blows and deflecting arrows, granting the wielder great agility.";
}