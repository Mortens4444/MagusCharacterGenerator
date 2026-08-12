using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.GameSystem.Valuables;
using MAGUS.Interfaces;

namespace MAGUS.Things.Weapons.Spears;

public class LightLance : Weapon, IMeleeWeapon
{
    public override double AttacksPerRound => 1;

    public override int InitiateValue => 2;

    public int AttackValue => 11;

    public int DefenseValue => 12;

    public override double Weight => 2;

    public override Money Price => new(0, 9);

    [DiceThrow(ThrowType._1D10)]
    public override int GetDamage() => DiceThrow._1D10();

    override public string Name => "Light lance";

    public override string Description => "A slender, shorter lance used by light horsemen or skirmishers. Easier to handle than a heavy lance but lacking its sheer destructive force.";
}