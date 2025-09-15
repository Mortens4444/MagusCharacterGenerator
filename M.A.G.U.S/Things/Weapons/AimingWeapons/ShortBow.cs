using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Weapons.AimingWeapons;

public class ShortBow : Weapon, IRangedWeapon
{
    public double AttacksPerRound => 2;

    public byte InitiatingValue => 5;

    public byte AimingValue => 4;

    public ushort Distance => 90;

    public double Weight => 0.6;

    public Money Price => new(3);

    [DiceThrow(ThrowType._1K6)]
    public byte GetDamage() => (byte)DiceThrow._1K6_RangedAttack();

    public override string Name => "Short bow";
}