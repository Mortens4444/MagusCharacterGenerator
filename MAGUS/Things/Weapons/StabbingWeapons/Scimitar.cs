using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.GameSystem.Valuables;
using MAGUS.Interfaces;

namespace MAGUS.Things.Weapons.StabbingWeapons;

public class Scimitar : Weapon, IMeleeWeapon
{
    public override double AttacksPerRound => 1;

    public override int InitiateValue => 6;

    public int AttackValue => 14;

    public int DefenseValue => 15;

    public override double Weight => 2;

    public override Money Price => new(1, 5);

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(3)]
    public override int GetDamage() => DiceThrow._1D6() + 3;

    public override string Name => "Sword, scimitar";

    public override string Description => "A deeply curved, single-edged blade from the Southern realms, designed to maximize cutting power and commonly associated with desert warriors.";
}