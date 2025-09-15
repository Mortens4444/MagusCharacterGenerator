using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Weapons.CrushingWeapons;

public class Warhammer : Weapon, IMeleeWeapon
{
    public double AttacksPerRound => 1;

    public byte InitiatingValue => 5;

    public byte AttackingValue => 10;

    public byte DefendingValue => 8;

    public double Weight => 3;

    public Money Price => new(0, 8);

    [DiceThrow(ThrowType._1K6)]
    [DiceThrowModifier(2)]
    public byte GetDamage() => (byte)(DiceThrow._1K6() + 2);
}