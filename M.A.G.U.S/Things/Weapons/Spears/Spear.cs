using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Weapons.Spears;

public class Spear : Weapon, IMeleeWeapon
{
    public double AttacksPerRound => 1;

    public int InitiatingValue => 4;

    public int AttackingValue => 12;

    public int DefendingValue => 12;

    public override double Weight => 2;

    public override Money Price => new(0, 8);

    [DiceThrow(ThrowType._1D10)]
    public override int GetDamage() => DiceThrow._1D10();

    public override string Description => "A simple wooden shaft with a sharp metal head. The most common weapon in the world, used for thrusting, throwing, and guarding against cavalry.";
}