using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Models;

namespace MAGUS.Bestiary.Animals;

public sealed class Scorpion : Creature
{
    public Scorpion()
    {
        Occurrence = Occurrence.Frequent;
        PlacesOfOccurrence = TerrainType.Anywhere;
        Size = Size.Small;

        HealthPoints = 1;

        PoisonResistance = 8;

        Intelligence = Enums.Intelligence.Animal;
    }

    [DiceThrowModifier(1)]
    public override int GetDamage() => 1; // + add poison damage

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 5)];
}
