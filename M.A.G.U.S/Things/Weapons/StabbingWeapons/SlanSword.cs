using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;
using M.A.G.U.S.Things.Weapons;

namespace M.A.G.U.S.Things.StabbingWeapons;

public class SlanSword : Weapon, IMeleeWeapon
{
    public double AttacksPerRound => 1;

    public byte InitiatingValue => 8;

    public byte AttackingValue => 20;

    public byte DefendingValue => 12;

    public override double Weight => 1.4;

    public override Money Price => new(100);

    [DiceThrow(ThrowType._1K10)]
    public byte GetDamage() => (byte)(DiceThrow._1K10() + 2);

    public override string Name => "Slan sword";
}