using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.GameSystem.Valuables;
using MAGUS.Interfaces;

namespace MAGUS.Things.Weapons.StabbingWeapons;

public class KnightSword : Weapon, IMeleeWeapon
{
    public override double AttacksPerRound => 1;

    public override int InitiateValue => 2;

    public int AttackValue => 10;

    public int DefenseValue => 7;

    public override double Weight => 3.5;

    public override Money Price => new(3);

    [DiceThrow(ThrowType._2D6)]
    [DiceThrowModifier(6)]
    public override int GetDamage() => DiceThrow._2D6() + 6;

    public override string Name => "Knight's sword";

    public override string Description => "A classic, straight-bladed sword of exceptional quality and balance, fit for a mounted or foot knight. Its guard is often adorned with noble insignia.";
}