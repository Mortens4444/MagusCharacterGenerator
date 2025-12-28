using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;
using M.A.G.U.S.Interfaces;

namespace M.A.G.U.S.Things.Weapons.RangedWeapons;

public class Shortbow : Weapon, IRangedWeapon
{
    public override double AttacksPerRound => 2;

    public override int InitiateValue => 5;

    public int AimValue => 4;

    public int Distance => 90;

    public override double Weight => 0.6;

    public override Money Price => new(3);

    [DiceThrow(ThrowType._1D6_Ranged)]
    public override int GetDamage() => DiceThrow._1D6_RangedAttack();

    public override string Description => "A small, simple bow used for hunting small game or by those with little strength. Its range and power are limited, but it is easy to master.";
}