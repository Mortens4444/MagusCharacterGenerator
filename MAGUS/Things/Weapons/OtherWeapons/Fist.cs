using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.GameSystem.Valuables;
using MAGUS.Interfaces;

namespace MAGUS.Things.Weapons.OtherWeapons;

public class Fist : Weapon, IMeleeWeapon
{
    public override double AttacksPerRound => 2;

    public override int InitiateValue => 10;

    public int AttackValue => 4;

    public int DefenseValue => 1;

    public override double Weight => 0;

    public override Money Price => Money.Free;

    [DiceThrow(ThrowType._1D2)]
    public override int GetDamage() => DiceThrow._1D2();

    public override string Description => "The natural weapon of the hand, used when steel is unavailable or forbidden. Though rarely deadly, a trained fist can knock a foe senseless.";
}