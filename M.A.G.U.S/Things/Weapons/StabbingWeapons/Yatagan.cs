using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Weapons.StabbingWeapons;

public class Yatagan : Weapon, IMeleeWeapon
{
    public double AttacksPerRound => 1;

    public byte InitiatingValue => 7;

    public byte AttackingValue => 14;

    public byte DefendingValue => 14;

    public override double Weight => 0.8;

    public override Money Price => new(1, 4);

    [DiceThrow(ThrowType._1K6)]
    [DiceThrowModifier(2)]
    public byte GetDamage() => (byte)(DiceThrow._1K6() + 2);

    public override string Name => "Sword, yataghan";

    public override string Description => "A curved, single-edged sword with a distinctive flared tip, common in Eastern armies. Designed for powerful, deep cutting strokes.";
}