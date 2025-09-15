using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Weapons.AimingWeapons;

public class Sling : Weapon, IRangedWeapon
{
    public double AttacksPerRound => 2;

    public byte InitiatingValue => 2;

    public byte AimingValue => 1;

    public ushort Distance => 100;

    public double Weight => 0.1;

    public Money Price => new(0, 0, 30);

    [DiceThrow(ThrowType._1K5)]
    public byte GetDamage() => (byte)DiceThrow._1K5_RangedAttack();
}