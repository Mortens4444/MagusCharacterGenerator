using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.GameSystem.Valuables;
using MAGUS.Interfaces;

namespace MAGUS.Things.Weapons.RangedWeapons;

public class AquirianCrossbow : Weapon, IRangedWeapon
{
    public override double AttacksPerRound => 2;

    public override int InitiateValue => 5;

    public int AimValue => 18;

    public int Distance => 35;

    public override double Weight => 2;

    public override Money Price => new(1000);

    [DiceThrow(ThrowType._1D5_Ranged)]
    public override int GetDamage() => DiceThrow._1D5_RangedAttack();

    public override string Name => "Aquirian crossbow";

    public override string Description => "A specialized crossbow of Aquirian make, known for its fine balance and silent release. Preferred by skilled rangers and urban hunters.";
}