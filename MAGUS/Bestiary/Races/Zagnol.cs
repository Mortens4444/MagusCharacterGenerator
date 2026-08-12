using MAGUS.Enums;
using MAGUS.GameSystem;
using MAGUS.GameSystem.Attributes;
using MAGUS.Models;

namespace MAGUS.Bestiary.Races;

public sealed class Zagnol : Creature
{
    public Zagnol()
    {
        Occurrence = Occurrence.Frequent;
        Size = Size.Huge;
        PlacesOfOccurrence = TerrainType.Anywhere;

        AttackValue = 65;
        DefenseValue = 100;
        InitiateValue = 34;

        HealthPoints = 19;
        PainTolerancePoints = 55;

        PoisonResistance = 9;
        AstralMagicResistance = 15;
        MentalMagicResistance = 15;

        AttacksPerRound = 2;

        Intelligence = Enums.Intelligence.Average;
        Alignment = Alignment.ChaosDeath;
        ExperiencePoints = 125;
    }

    [DiceThrow(ThrowType._1D10)]
    public override int GetNumberAppearing() => DiceThrow._1D10();

    [DiceThrow(ThrowType._1D10)]
    [DiceThrowModifier(3)]
    public override int GetDamage() => DiceThrow._1D10() + 3;

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 90)];
}