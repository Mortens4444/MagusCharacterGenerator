using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Weapons.RangedWeapons;

public class Shortbow : Weapon, IRangedWeapon
{
    public double AttacksPerRound => 2;

    public byte InitiatingValue => 5;

    public byte AimingValue => 4;

    public ushort Distance => 90;

    public override double Weight => 0.6;

    public override Money Price => new(3);

    [DiceThrow(ThrowType._1D6)]
    public byte GetDamage() => (byte)DiceThrow._1D6_RangedAttack();

    public override string Description => "A small, simple bow used for hunting small game or by those with little strength. Its range and power are limited, but it is easy to master.";
}