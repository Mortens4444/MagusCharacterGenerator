using MAGUS.Enums;
using MAGUS.GameSystem;
using MAGUS.GameSystem.Attributes;
using MAGUS.Models;
using MAGUS.Things.Armors;

namespace MAGUS.Bestiary.Animals;

public sealed class CrocodileOnLand : Creature
{
    public CrocodileOnLand()
    {
        Armor = new NaturalArmor(5);
        PlacesOfOccurrence = TerrainType.TropicalRiver | TerrainType.Swamp;
        Size = Size._6_to_8_meters;
        Occurrence = Occurrence.Rare;

        AttackValue = 55;
        DefenseValue = 60;
        InitiateValue = 35;

        HealthPoints = 45;
        PainTolerancePoints = 90;

        PoisonResistance = 5;

        Intelligence = Enums.Intelligence.Animal;
        ExperiencePoints = 200;
    }

    public override string Name => "Crocodile (on land)";

    public override string[] Images => ["crocodile.png"];

    [DiceThrow(ThrowType._3D6)]
    public override int GetDamage() => DiceThrow._3D6();

    [DiceThrow(ThrowType._1D5)]
    public override int GetNumberAppearing() => DiceThrow._1D5();

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 35), new Speed(TravelMode.InWater, 120)];
}
