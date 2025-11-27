using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Weapons.StabbingWeapons;

public class Broadsword : Weapon, IMeleeWeapon
{
    public double AttacksPerRound => 1 / 2;

    public byte InitiatingValue => 0;

    public byte AttackingValue => 6;

    public byte DefendingValue => 2;

    public override double Weight => 7;

    public override Money Price => new(5);

    [DiceThrow(ThrowType._3K6)]
    [DiceThrowModifier(2)]
    public byte GetDamage() => (byte)(DiceThrow._3K6() + 2);

    override public string Name => "Sword, greatsword";

    public override string Description => "A wide-bladed, heavy sword designed primarily for powerful cutting and cleaving blows rather than piercing thrusts.";
}