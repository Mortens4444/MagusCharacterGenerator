using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Weapons.Spears;

public class Halberd : Weapon, IMeleeWeapon
{
    public double AttacksPerRound => 1 / 2;

    public byte InitiatingValue => 1;

    public byte AttackingValue => 14;

    public byte DefendingValue => 15;

    public double Weight => 3;

    public Money Price => new(5);

    [DiceThrow(ThrowType._2K6)]
    [DiceThrowModifier(2)]
    public byte GetDamage() => (byte)(DiceThrow._2K6() + 2);
}