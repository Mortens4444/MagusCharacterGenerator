using MAGUS.Enums;
using MAGUS.GameSystem;
using MAGUS.GameSystem.Attributes;
using MAGUS.Models;
using MAGUS.Things.Armors;

namespace MAGUS.Bestiary.Animals;

public sealed class Crocodile : Creature
{
    public Crocodile()
    {
        Armor = new NaturalArmor(5);
        PlacesOfOccurrence = TerrainType.TropicalRiver | TerrainType.Swamp;
        Occurrence = Occurrence.Rare;
        Size = Size._6_to_8_meters;

        AttackValue = 55;
        DefenseValue = 100;
        InitiateValue = 50;
        
        HealthPoints = 45;
        PainTolerancePoints = 90;

        PoisonResistance = 5;

        Intelligence = Enums.Intelligence.Animal;
        ExperiencePoints = 200;
    }

    [DiceThrow(ThrowType._3D6)]
    public override int GetDamage() => DiceThrow._3D6();

    [DiceThrow(ThrowType._1D5)]
    public override int GetNumberAppearing() => DiceThrow._1D5();

    public override List<Speed> Speeds => [new Speed(TravelMode.InWater, 120), new Speed(TravelMode.OnLand, 35)];
}
