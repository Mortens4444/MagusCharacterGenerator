using MAGUS.Enums;
using MAGUS.GameSystem;
using MAGUS.GameSystem.Attributes;
using MAGUS.Models;
using MAGUS.Things.Armors;

namespace MAGUS.Bestiary.Animals;

public sealed class GiantSpider : Creature
{
    public GiantSpider()
    {
        Armor = new NaturalArmor(2);
        PlacesOfOccurrence = TerrainType.TropicalForest;

        Occurrence = Occurrence.VeryRare;
        Size = Size.Small;
        AttackValue = 30;
        DefenseValue = 60;
        InitiateValue = 25;
        HealthPoints = 6;
        PainTolerancePoints = 13;
        PoisonResistance = 8;
        Intelligence = Enums.Intelligence.Animal;
        ExperiencePoints = 3;
    }

    public override string Name => "Giant spider";

    [DiceThrow(ThrowType._1D3)]
    public override int GetDamage() => DiceThrow._1D3();

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 80)];
}
