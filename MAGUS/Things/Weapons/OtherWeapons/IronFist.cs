using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.GameSystem.Valuables;
using MAGUS.Interfaces;

namespace MAGUS.Things.Weapons.OtherWeapons;

public class IronFist : Weapon, IMeleeWeapon
{
    public override double AttacksPerRound => 2;

    public override int InitiateValue => 9;

    public int AttackValue => 5;

    public int DefenseValue => 2;

    public override double Weight => 0.2;

    public override Money Price => new(0, 1);

    [DiceThrow(ThrowType._1D3)]
    public override int GetDamage() => DiceThrow._1D3();

    public override string Name => "Iron fist (knuckle)";

    public override string[] Images => ["iron_fist.png"];

    public override string Description => "A heavy gauntlet or fist-wrap of iron, designed to greatly augment the damage done by a punch, capable of shattering a jaw or cracking a rib.";
}