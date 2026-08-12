using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.GameSystem.Valuables;
using MAGUS.Interfaces;

namespace MAGUS.Things.Weapons.RangedWeapons;

public class Sling : Weapon, IRangedWeapon
{
    public override double AttacksPerRound => 2;

    public override int InitiateValue => 2;

    public int AimValue => 1;

    public int Distance => 100;

    public override double Weight => 0.1;

    public override Money Price => new(0, 0, 30);

    [DiceThrow(ThrowType._1D5)]
    public override int GetDamage() => DiceThrow._1D5_RangedAttack();

    public override string Description => "A simple strap of leather or woven material used to hurl stones or lead pellets. Though cheap and requiring practice, it can deliver a deadly blow at range.";
}