using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Weapons.StabbingWeapons;

public class Longsword : Weapon, IMeleeWeapon
{
    public double AttacksPerRound => 1;

    public byte InitiatingValue => 6;

    public byte AttackingValue => 14;

    public byte DefendingValue => 16;

    public override double Weight => 1.5;

    public override Money Price => new(1, 5);

    [DiceThrow(ThrowType._1K10)]
    public byte GetDamage() => (byte)DiceThrow._1K10();
}