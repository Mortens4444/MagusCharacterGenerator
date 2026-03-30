using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Animals;

public sealed class SynmenBat : Creature
{
    public SynmenBat()
    {
        Occurrence = Occurrence.Frequent;
        Size = Size.Small;
        PlacesOfOccurrence = TerrainType.Forest | TerrainType.ArcticForest;

        AttackValue = 25;
        DefenseValue = 60;
        InitiateValue = 10;
        AimValue = 50;

        HealthPoints = 2;
        PainTolerancePoints = 6;

        PoisonResistance = 1;

        Intelligence = Enums.Intelligence.Animal;
        ExperiencePoints = 15;
    }

    [DiceThrow(ThrowType._2D10)]
    [DiceThrowModifier(10)]
    public override int GetNumberAppearing() => 10 + DiceThrow._2D10();

    [DiceThrow(ThrowType._1D3)]
    public override int GetDamage() => DiceThrow._1D3();

    public override List<Speed> Speeds => [new Speed(TravelMode.InTheAir, 90)];

    public override string Name => "Synmen Bat";
}