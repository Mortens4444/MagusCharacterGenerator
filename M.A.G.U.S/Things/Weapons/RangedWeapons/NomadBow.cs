using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Weapons.AimingWeapons;

public class NomadBow : Weapon, IRangedWeapon
{
    public double AttacksPerRound => 2;

    public byte InitiatingValue => 3;

    public byte AimingValue => 8;

    public ushort Distance => 180;

    public double Weight => 0.7;

    public override Money Price => new(25);

    [DiceThrow(ThrowType._1K10)]
    public byte GetDamage() => (byte)DiceThrow._1K10_RangedAttack();

    public override string Name => "Nomad bow";
}