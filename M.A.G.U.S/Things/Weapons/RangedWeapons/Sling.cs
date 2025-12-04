using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Weapons.RangedWeapons;

public class Sling : Weapon, IRangedWeapon
{
    public double AttacksPerRound => 2;

    public byte InitiatingValue => 2;

    public byte AimingValue => 1;

    public ushort Distance => 100;

    public override double Weight => 0.1;

    public override Money Price => new(0, 0, 30);

    [DiceThrow(ThrowType._1D5)]
    public byte GetDamage() => (byte)DiceThrow._1D5_RangedAttack();

    public override string Description => "A simple strap of leather or woven material used to hurl stones or lead pellets. Though cheap and requiring practice, it can deliver a deadly blow at range.";
}