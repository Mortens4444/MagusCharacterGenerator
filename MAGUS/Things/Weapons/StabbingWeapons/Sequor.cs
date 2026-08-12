using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.GameSystem.Valuables;
using MAGUS.Interfaces;

namespace MAGUS.Things.Weapons.StabbingWeapons;

public class Sequor : Weapon, IMeleeWeapon
{
    public override double AttacksPerRound => 2;

    public override int InitiateValue => 8;

    public int AttackValue => 13;

    public int DefenseValue => 16;

    public override double Weight => 0.4;

    public override Money Price => new(1, 3);

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(2)]
    public override int GetDamage() => DiceThrow._1D6() + 2;

    public override string Description => "A standard, efficient cutting sword used by legionaries and professional soldiers, designed for reliable, steady performance in formation combat.";
}