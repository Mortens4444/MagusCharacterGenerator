using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.GameSystem.Valuables;
using MAGUS.Interfaces;

namespace MAGUS.Things.Weapons.OtherWeapons;

public class ParryingDagger : Weapon, IMeleeWeapon
{
    public override double AttacksPerRound => 2;

    public override int InitiateValue => 8;

    public int AttackValue => 4;

    public int DefenseValue => 19;

    public override double Weight => 0.3;

    public override Money Price => new(0, 2);

    [DiceThrow(ThrowType._1D6)]
    public override int GetDamage() => DiceThrow._1D6();

    public override string Name => "Parrying dagger";

    public override string Description => "A sturdy, often broad-bladed dagger held in the off-hand, used primarily to deflect and catch enemy blades during a sword fight.";
}