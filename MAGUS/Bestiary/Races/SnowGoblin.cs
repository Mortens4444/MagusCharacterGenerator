using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Models;
using MAGUS.Things.Armors;

namespace MAGUS.Bestiary.Races;

public sealed class SnowGoblin : Creature
{
    public SnowGoblin()
    {
        Armor = new NaturalArmor(1);
        Occurrence = Occurrence.Frequent;
        Size = Size.Small;
        PlacesOfOccurrence = TerrainType.Icefield | TerrainType.Snowfield;

        AttackValue = 25;
        DefenseValue = 60;
        InitiateValue = 10;
        AimValue = 10;

        HealthPoints = 10;
        PainTolerancePoints = 15;

        PoisonResistance = 5;

        Intelligence = Enums.Intelligence.Low;
        Alignment = Alignment.Chaos;
        ExperiencePoints = 13;
    }

    public override string Name => "Snow Goblin";

    [DiceThrow(ThrowType._1D6)]
    public override int GetDamage() => DiceThrow._1D6(); // Weapon-dependent

    [DiceThrow(ThrowType._1D100)]
    public override int GetNumberAppearing() => DiceThrow._1D100();

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 50)];
}