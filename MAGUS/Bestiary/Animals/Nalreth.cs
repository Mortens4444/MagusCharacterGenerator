using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Models;
using MAGUS.Things.Armors;

namespace MAGUS.Bestiary.Animals;

public sealed class Nalreth : Creature
{
    public Nalreth()
    {
        Armor = new NaturalArmor(3);
        Occurrence = Occurrence.Frequent;
        Size = Size._7_to_11_meters;
        PlacesOfOccurrence = TerrainType.CursedLand;

        InitiateValue = 55;
        //AttackValue = 0;
        DefenseValue = 50;
        AimValue = 35;

        HealthPoints = 35;

        AstralMagicResistance = Int32.MaxValue;
        MentalMagicResistance = Int32.MaxValue;
        PoisonResistance = 7;
        
        Intelligence = Enums.Intelligence.Animal;
        ExperiencePoints = 300;
    }

    [DiceThrow(ThrowType._1D6)]
    public override int GetDamage() => DiceThrow._1D6();

    [DiceThrow(ThrowType._1D10)]
    [DiceThrowModifier(5)]
    public override int GetNumberAppearing() => DiceThrow._1D10() + 5;

    public override List<Speed> Speeds => [new Speed(TravelMode.InTheAir, 120), new Speed(TravelMode.OnLand, 30)];
}
