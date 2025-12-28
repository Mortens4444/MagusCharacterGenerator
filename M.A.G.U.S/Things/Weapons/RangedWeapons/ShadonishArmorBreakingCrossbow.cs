using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;
using M.A.G.U.S.Interfaces;

namespace M.A.G.U.S.Things.Weapons.RangedWeapons;

public class ShadonishArmorBreakingCrossbow : Weapon, IRangedWeapon
{
    public override double AttacksPerRound => 1 / 5;

    public override int InitiateValue => 0;

    public int AimValue => 17;

    public int Distance => 80;

    public override double Weight => 8;

    public override Money Price => new(40);

    [DiceThrow(ThrowType._2D10_Ranged)]
    public override int GetDamage() => DiceThrow._2D10_RangedAttack();

    public override string Name => "Shadonian armor-piercing crossbow";

    public override string Description => "A brutally powerful crossbow engineered by Shadonish smiths, specifically designed to penetrate the thickest plate armour with a heavy, piercing bolt.";
}