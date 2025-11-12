using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Weapons.StabbingWeapons;

public class ThrowingAx : Weapon, IMeleeWeapon
{
    public double AttacksPerRound => 2;

    public byte InitiatingValue => 9;

    public byte AttackingValue => 10;

    public byte DefendingValue => 4;

    public override double Weight => 1.2;

    public override Money Price => new(0, 1);

    [DiceThrow(ThrowType._1K6)]
    public byte GetDamage() => (byte)DiceThrow._1K6();

    public override string Name => "Throwing axe";
}