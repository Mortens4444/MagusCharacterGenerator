using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.GameSystem.Valuables;
using MAGUS.Interfaces;

namespace MAGUS.Things.Weapons.CrushingWeapons;

public class CarvedClub : Weapon, IMeleeWeapon
{
    public override double AttacksPerRound => 1;

    public override int InitiateValue => 2;

    public int AttackValue => 7;

    public int DefenseValue => 14;

    public override double Weight => 1.3;

    public override Money Price => Money.Free;

    [DiceThrow(ThrowType._1D6)]
    public override int GetDamage() => DiceThrow._1D6();

    public override string Name => "Club";

    public override string Description => "A heavy cudgel of wood, often crudely fashioned but decorated with simple carvings. The common weapon of bandits, peasants, or those with little coin for true steel.";
}