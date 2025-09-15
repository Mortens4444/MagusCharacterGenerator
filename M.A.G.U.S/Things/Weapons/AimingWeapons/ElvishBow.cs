using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Weapons.AimingWeapons;

public class ElvishBow : Weapon, IRangedWeapon
{
    public double AttacksPerRound => 2;

    public byte InitiatingValue => 6;

    public byte AimingValue => 10;

    public ushort Distance => 120;

    public double Weight => 0.7;

    public Money Price => new(120);

    public byte GetDamage() => (byte)DiceThrow._2K6_RangedAttack();

    public override string Name => "Elvish bow";
}