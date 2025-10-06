using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Weapons.AimingWeapons;

public class LightCrossbow : Weapon, IRangedWeapon
{
    public double AttacksPerRound => 1;

    public byte InitiatingValue => 2;

    public byte AimingValue => 16;

    public ushort Distance => 50;

    public override double Weight => 3.5;

    public override Money Price => new(8);

    [DiceThrow(ThrowType._1K6)]
    [DiceThrowModifier(1)]
    public byte GetDamage() => (byte)(DiceThrow._1K6_RangedAttack() + 1);

    public override string Name => "Light crossbow";
}