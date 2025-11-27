using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Weapons.RangedWeapons;

public class HeavyCrossbow : Weapon, IRangedWeapon
{
    public double AttacksPerRound => 1 / 3;

    public byte InitiatingValue => 0;

    public byte AimingValue => 15;

    public ushort Distance => 60;

    public override double Weight => 6;

    public override Money Price => new(12);

    [DiceThrow(ThrowType._1K10)]
    [DiceThrowModifier(2)]
    public byte GetDamage() => (byte)(DiceThrow._1K10_RangedAttack() + 2);

    public override string Name => "Heavy crossbow";

    public override string Description => "A massive, powerful crossbow requiring a crank or lever to draw its immense string. Its bolt can pierce heavy armour but takes a long time to reload.";
}