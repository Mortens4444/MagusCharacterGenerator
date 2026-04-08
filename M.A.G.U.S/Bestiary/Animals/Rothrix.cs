using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Animals;

public sealed class Rothrix : Creature
{
    public Rothrix()
    {
        Occurrence = Occurrence.Frequent;
        Size = Size.Small;
        PlacesOfOccurrence = TerrainType.CursedLand;

        AttackValue = 45;
        DefenseValue = 95;
        InitiateValue = 15;

        HealthPoints = 5;
        PainTolerancePoints = 25;

        AstralMagicResistance = 8;
        MentalMagicResistance = 6;
        PoisonResistance = 7;

        Intelligence = Enums.Intelligence.Animal;
        Alignment = Alignment.Death;
        ExperiencePoints = 20;
    }

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(1)]
    public override int GetDamage() => DiceThrow._1D6() + 1;

    [DiceThrow(ThrowType._2D6)]
    [DiceThrowModifier(4)]
    public override int GetNumberAppearing() => DiceThrow._2D6() + 4;

    public override List<Speed> Speeds => [new Speed(TravelMode.InTheAir, 150)];
}