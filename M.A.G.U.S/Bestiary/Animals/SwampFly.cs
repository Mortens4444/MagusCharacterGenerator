using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Animals;

public sealed class SwampFly : Creature
{
    public SwampFly()
    {
        Occurrence = Occurrence.Rare;
        Size = Size.Human;
        PlacesOfOccurrence = TerrainType.Swamp;
        Country = GameSystem.Places.Country.Shadon;

        DefenseValue = 100;
        InitiateValue = 38;
        AimValue = 40;

        AttacksPerRound = 0.5;

        HealthPoints = 16;
        PainTolerancePoints = 46;

        PoisonResistance = 7;

        Intelligence = Enums.Intelligence.Animal;
        ExperiencePoints = 55;
    }

    [DiceThrow(ThrowType._2D6)]
    public override int GetDamage() => DiceThrow._2D6();

    [DiceThrow(ThrowType._1D10)]
    public override int GetNumberAppearing() => DiceThrow._1D10();

    public override string Name => "Swamp fly";

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 60), new Speed(TravelMode.InTheAir, 150)];
}
