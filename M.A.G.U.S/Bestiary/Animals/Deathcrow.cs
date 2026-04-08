using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Animals;

public sealed class Deathcrow : Creature
{
    public Deathcrow()
    {
        Occurrence = Occurrence.Frequent;
        Size = Size.Small;
        PlacesOfOccurrence = TerrainType.Anywhere;

        AttackValue = 60;
        DefenseValue = 98;
        InitiateValue = 28;

        HealthPoints = 4;
        PainTolerancePoints = 16;

        AstralMagicResistance = 8;
        MentalMagicResistance = 8;
        PoisonResistance = 6;

        Intelligence = Enums.Intelligence.Low;
        Alignment = Alignment.Death;
        ExperiencePoints = 10;
    }

    [DiceThrow(ThrowType._1D3)]
    public override int GetDamage() => DiceThrow._1D3();

    [DiceThrow(ThrowType._1D10)]
    public override int GetNumberAppearing() => DiceThrow._1D10();

    public override List<Speed> Speeds => [new Speed(TravelMode.InTheAir, 120)];

    //public override string[] Sounds => ["crow", "crow_2", "crow_3"];
}
