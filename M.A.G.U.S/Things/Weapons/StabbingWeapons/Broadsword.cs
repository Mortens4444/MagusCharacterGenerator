using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;
using M.A.G.U.S.Interfaces;

namespace M.A.G.U.S.Things.Weapons.StabbingWeapons;

public class Broadsword : Weapon, IMeleeWeapon
{
    public override double AttacksPerRound => 1 / 2;

    public int InitiateValue => 0;

    public int AttackValue => 6;

    public int DefenseValue => 2;

    public override double Weight => 7;

    public override Money Price => new(5);

    [DiceThrow(ThrowType._3D6)]
    [DiceThrowModifier(2)]
    public override int GetDamage() => DiceThrow._3D6() + 2;

    override public string Name => "Sword, greatsword";

    public override string Description => "A wide-bladed, heavy sword designed primarily for powerful cutting and cleaving blows rather than piercing thrusts.";
}