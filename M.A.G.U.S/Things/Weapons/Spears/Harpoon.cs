using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;
using M.A.G.U.S.Interfaces;

namespace M.A.G.U.S.Things.Weapons.Spears;

public class Harpoon : Weapon, IMeleeWeapon
{
    public override double AttacksPerRound => 1;

    public int InitiateValue => 4;

    public int AttackValue => 15;

    public int DefenseValue => 10;

    public override double Weight => 2;

    public override Money Price => new(0, 5);

    [DiceThrow(ThrowType._1D10)]
    [DiceThrowModifier(1)]
    public override int GetDamage() => DiceThrow._1D10() + 1;

    public override string Name => "Trident";

    public override string Description => "A long spear with a barbed head attached to a retrieval rope. Used primarily for hunting great sea beasts or securing small ships.";
}