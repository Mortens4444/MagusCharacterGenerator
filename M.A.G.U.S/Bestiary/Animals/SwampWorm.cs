using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Animals;

public sealed class SwampWorm : Creature
{
    public SwampWorm()
    {
        Occurrence = Occurrence.Rare;
        Size = Size.Human;
        PlacesOfOccurrence = TerrainType.Swamp;
        Country = GameSystem.Places.Country.Shadon;

        AttackValue = 40;
        DefenseValue = 80;
        InitiateValue = 10;
        AimValue = 26;

        AttacksPerRound = 1d / 6d;

        HealthPoints = 18;
        PainTolerancePoints = 44;

        PoisonResistance = 7;

        Intelligence = Enums.Intelligence.Animal;
        ExperiencePoints = 45;
    }

    [DiceThrow(ThrowType._1D10)]
    public override int GetDamage() => DiceThrow._1D10();

    [DiceThrow(ThrowType._1D10)]
    public override int GetNumberAppearing() => DiceThrow._1D10();

    public override string Name => "Swamp worm";

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 30), new Speed(TravelMode.InWater, 60)];
}
