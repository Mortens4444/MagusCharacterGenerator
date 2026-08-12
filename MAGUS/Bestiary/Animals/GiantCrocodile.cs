using MAGUS.Enums;
using MAGUS.GameSystem;
using MAGUS.GameSystem.Attributes;
using MAGUS.Models;
using MAGUS.Things.Armors;

namespace MAGUS.Bestiary.Animals;

public sealed class GiantCrocodile : Creature
{
    public GiantCrocodile()
    {
        Armor = new NaturalArmor(8);
        PlacesOfOccurrence = TerrainType.TropicalRiver | TerrainType.Swamp;

        Occurrence = Occurrence.Rare;
        PlacesOfOccurrence = TerrainType.Swamp;

        Size = Size.Up_to_15_meters;
        AttackValue = 65;
        DefenseValue = 120;
        InitiateValue = 65;
        HealthPoints = 55;
        PainTolerancePoints = 110;
        PoisonResistance = 8;
        Intelligence = Enums.Intelligence.Animal;
        ExperiencePoints = 310;
    }

    public override string Name => "Giant crocodile";

    [DiceThrow(ThrowType._5D6)]
    public override int GetDamage() => DiceThrow._5D6();

    [DiceThrow(ThrowType._1D3)]
    public override int GetNumberAppearing() => DiceThrow._1D3();

    public override List<Speed> Speeds => [new Speed(TravelMode.InWater, 120), new Speed(TravelMode.OnLand, 30)];
}
