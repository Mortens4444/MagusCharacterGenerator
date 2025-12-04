using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Weapons.Spears;

public class Harpoon : Weapon, IMeleeWeapon
{
    public double AttacksPerRound => 1;

    public byte InitiatingValue => 4;

    public byte AttackingValue => 15;

    public byte DefendingValue => 10;

    public override double Weight => 2;

    public override Money Price => new(0, 5);

    [DiceThrow(ThrowType._1D10)]
    [DiceThrowModifier(1)]
    public byte GetDamage() => (byte)(DiceThrow._1D10() + 1);

    public override string Name => "Trident";

    public override string Description => "A long spear with a barbed head attached to a retrieval rope. Used primarily for hunting great sea beasts or securing small ships.";
}