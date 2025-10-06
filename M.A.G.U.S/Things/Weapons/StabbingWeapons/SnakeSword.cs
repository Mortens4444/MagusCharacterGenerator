using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;
using M.A.G.U.S.Things.Weapons;

namespace M.A.G.U.S.Things.StabbingWeapons;

public class SnakeSword : Weapon, IMeleeWeapon
{
    public double AttacksPerRound => 1;

    public byte InitiatingValue => 6;

    public byte AttackingValue => 14;

    public byte DefendingValue => 15;

    public override double Weight => 1.4;

    public override Money Price => new(6);

    [DiceThrow(ThrowType._1K10)]
    public byte GetDamage() => (byte)DiceThrow._1K10();

    public override string Name => "Snake sword";
}