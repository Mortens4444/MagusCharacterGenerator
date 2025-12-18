using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Weapons.OtherWeapons;

public class Bola : Weapon, IMeleeWeapon
{
    public override double AttacksPerRound => 1;

    public int InitiateValue => 2;

    public int AttackValue => 10;

    public int DefenseValue => 2;

    public override double Weight => 0.8;

    public override Money Price => new(0, 0, 40);

    [DiceThrow(ThrowType._1D5)]
    [DiceThrowModifier(1)]
    public override int GetDamage() => DiceThrow._1D5() + 1;

    public override string Description => "A throwing weapon consisting of weights connected by cords. Thrown to entangle the legs of running beasts or men, bringing them down swiftly.";
}