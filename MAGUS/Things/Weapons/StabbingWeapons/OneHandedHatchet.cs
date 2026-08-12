using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.GameSystem.Valuables;
using MAGUS.Interfaces;

namespace MAGUS.Things.Weapons.StabbingWeapons;

public class OneHandedHatchet : Weapon, IMeleeWeapon
{
    public override double AttacksPerRound => 1;

    public override int InitiateValue => 5;

    public int AttackValue => 12;

    public int DefenseValue => 11;

    public override double Weight => 2;

    public override Money Price => new(0, 6);

    [DiceThrow(ThrowType._1D10)]
    public override int GetDamage() => DiceThrow._1D10();

    public override string Name => "One-handed axe";

    public override string Description => "A simple, single-handed axe used for both labour and combat. An inexpensive and versatile sidearm.";
}