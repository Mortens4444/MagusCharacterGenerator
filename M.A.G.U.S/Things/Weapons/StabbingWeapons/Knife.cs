using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;
using M.A.G.U.S.Things.Weapons;

namespace M.A.G.U.S.Things.StabbingWeapons;

public class Knife : Weapon, IMeleeWeapon
{
    public double AttacksPerRound => 2;

    public byte InitiatingValue => 10;

    public byte AttackingValue => 4;

    public byte DefendingValue => 0;

    public override double Weight => 0.2;

    public override Money Price => new(0, 0, 50);

    [DiceThrow(ThrowType._1K5)]
    public byte GetDamage() => (byte)DiceThrow._1K5();
}