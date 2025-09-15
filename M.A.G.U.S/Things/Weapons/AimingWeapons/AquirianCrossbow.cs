using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Weapons.AimingWeapons;

public class AquirianCrossbow : Weapon, IRangedWeapon
{
    public double AttacksPerRound => 2;

    public byte InitiatingValue => 5;

    public byte AimingValue => 18;

    public ushort Distance => 35;

    public double Weight => 2;

    public Money Price => new(1000);

    [DiceThrow(ThrowType._1K5)]
    public byte GetDamage() => (byte)DiceThrow._1K5_RangedAttack();

    public override string Name => "Aquirian crossbow";
}