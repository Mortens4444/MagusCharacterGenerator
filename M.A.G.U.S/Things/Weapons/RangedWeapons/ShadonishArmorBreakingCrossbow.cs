using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Weapons.RangedWeapons;

public class ShadonishArmorBreakingCrossbow : Weapon, IRangedWeapon
{
    public double AttacksPerRound => 1 / 5;

    public byte InitiatingValue => 0;

    public byte AimingValue => 17;

    public ushort Distance => 80;

    public override double Weight => 8;

    public override Money Price => new(40);

    public byte GetDamage() => (byte)DiceThrow._2D10_RangedAttack();

    public override string Name => "Shadonian armor-piercing crossbow";

    public override string Description => "A brutally powerful crossbow engineered by Shadonish smiths, specifically designed to penetrate the thickest plate armour with a heavy, piercing bolt.";
}