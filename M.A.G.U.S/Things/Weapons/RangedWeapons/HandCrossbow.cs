using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Weapons.AimingWeapons;

public class HandCrossbow : Weapon, IRangedWeapon
{
    public double AttacksPerRound => 2;

    public byte InitiatingValue => 3;

    public byte AimingValue => 14;

    public ushort Distance => 30;

    public override double Weight => 2;

    public override Money Price => new(20);

    [DiceThrow(ThrowType._1K3)]
    public byte GetDamage() => (byte)DiceThrow._1K3_RangedAttack();

    public override string Name => "Hand crossbow";
}