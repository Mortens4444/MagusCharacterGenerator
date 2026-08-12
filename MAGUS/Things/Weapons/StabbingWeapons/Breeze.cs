using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.GameSystem.Valuables;
using MAGUS.Interfaces;

namespace MAGUS.Things.Weapons.StabbingWeapons;

public class Breeze : Weapon, IMeleeWeapon
{
    public override double AttacksPerRound => 2;

    public override int InitiateValue => 17;

    public int AttackValue => 20;

    public int DefenseValue => 21;

    public override double Weight => 0.5;

    public override Money Price => new(100);

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(2)]
    public override int GetDamage() => DiceThrow._1D6() + 2;

    public override string Description => "This is a very light weapon, resembling mostly an overlong dagger or a very short sword. Its craftsmanship is masterful and strongly magical.";
}