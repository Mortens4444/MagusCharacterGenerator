using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;
using M.A.G.U.S.Interfaces;

namespace M.A.G.U.S.Things.Weapons.Spears;

public class Spear : Weapon, IMeleeWeapon
{
    public override double AttacksPerRound => 1;

    public int InitiateValue => 4;

    public int AttackValue => 12;

    public int DefenseValue => 12;

    public override double Weight => 2;

    public override Money Price => new(0, 8);

    [DiceThrow(ThrowType._1D10)]
    public override int GetDamage() => DiceThrow._1D10();

    public override string Description => "A simple wooden shaft with a sharp metal head. The most common weapon in the world, used for thrusting, throwing, and guarding against cavalry.";
}