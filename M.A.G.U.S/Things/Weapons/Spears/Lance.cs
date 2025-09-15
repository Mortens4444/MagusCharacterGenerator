using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Weapons.Spears;

public class Lance : Weapon, IMeleeWeapon
{
    public double AttacksPerRound => 1;

    public byte InitiatingValue => 2;

    public byte AttackingValue => 11;

    public byte DefendingValue => 12;

    public double Weight => 2;

    public Money Price => new(0, 9);

    [DiceThrow(ThrowType._1K10)]
    public byte GetDamage() => (byte)(DiceThrow._1K10());
}