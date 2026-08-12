using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.GameSystem.Valuables;
using MAGUS.Interfaces;

namespace MAGUS.Things.Weapons.StabbingWeapons;

public class Longsword : Weapon, IMeleeWeapon
{
    public override double AttacksPerRound => 1;

    public override int InitiateValue => 6;

    public int AttackValue => 14;

    public int DefenseValue => 16;

    public override double Weight => 1.5;

    public override Money Price => new(1, 5);

    [DiceThrow(ThrowType._1D10)]
    public override int GetDamage() => DiceThrow._1D10();

    public override string Description => "A long, two-edged, straight sword wielded primarily with two hands for powerful cuts and thrusts, a symbol of high skill and dedication to martial prowess.";
}