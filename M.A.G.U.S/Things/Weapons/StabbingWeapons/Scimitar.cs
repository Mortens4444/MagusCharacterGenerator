using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;
using M.A.G.U.S.Things.Weapons;

namespace M.A.G.U.S.Things.StabbingWeapons;

public class Scimitar : Weapon, IMeleeWeapon
{
    public double AttacksPerRound => 1;

    public byte InitiatingValue => 6;

    public byte AttackingValue => 14;

    public byte DefendingValue => 15;

    public double Weight => 2;

    public Money Price => new(1, 5);

    [DiceThrow(ThrowType._1K6)]
    [DiceThrowModifier(3)]
    public byte GetDamage() => (byte)(DiceThrow._1K6() + 3);
}