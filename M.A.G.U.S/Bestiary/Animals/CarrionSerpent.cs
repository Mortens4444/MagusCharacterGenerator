using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Animals;

public sealed class CarrionSerpent : Creature
{
    public CarrionSerpent()
    {
        Occurrence = Occurrence.Rare;
        Size = Size.Small;
        Country = GameSystem.Places.Country.Kran;
        PlacesOfOccurrence = TerrainType.Mountains | TerrainType.Cave;

        AttackValue = 30;
        DefenseValue = 40;
        InitiateValue = 30;

        HealthPoints = 3;
        PainTolerancePoints = 6;

        PoisonResistance = 4;

        Intelligence = Enums.Intelligence.Animal;
        ExperiencePoints = 3;
    }

    public override string Name => "Carrion Serpent";

    public override string[] Images => ["carrion_serpent.png"];

    [DiceThrow(ThrowType._1D2)]
    public override int GetDamage() => DiceThrow._1D2(); // + méreg

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    public override List<Speed> Speeds =>
    [
        new Speed(TravelMode.OnLand, 18),
        new Speed(TravelMode.InWater, 8)
    ];
}