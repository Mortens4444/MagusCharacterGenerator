using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Weapons.OtherWeapons;

public class Bola : Weapon, IMeleeWeapon
{
    public double AttacksPerRound => 1;

    public byte InitiatingValue => 2;

    public byte AttackingValue => 10;

    public byte DefendingValue => 2;

    public double Weight => 0.8;

    public override Money Price => new(0, 0, 40);

    [DiceThrow(ThrowType._1K5)]
    [DiceThrowModifier(1)]
    public byte GetDamage() => (byte)(DiceThrow._1K5() + 1);
}