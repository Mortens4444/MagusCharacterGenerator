using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Weapons.AimingWeapons;

public class ShadonishArmorBreakingCrossbow : Weapon, IRangedWeapon
{
    public double AttacksPerRound => 1 / 5;

    public byte InitiatingValue => 0;

    public byte AimingValue => 17;

    public ushort Distance => 80;

    public double Weight => 8;

    public override Money Price => new(40);

    public byte GetDamage() => (byte)DiceThrow._2K10_RangedAttack();

    public override string Name => "Shadonian armor-piercing crossbow";
}