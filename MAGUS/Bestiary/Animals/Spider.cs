using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Models;

namespace MAGUS.Bestiary.Animals;

public sealed class Spider : Creature
{
    public Spider()
    {
        Occurrence = Occurrence.Frequent;
        PlacesOfOccurrence = TerrainType.Anywhere;
        Size = Size.Small;

        HealthPoints = 1;

        PoisonResistance = 8;

        Intelligence = Enums.Intelligence.Animal;
    }

    [DiceThrowModifier(0)]
    public override int GetDamage() => 0;

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 5)];
}
