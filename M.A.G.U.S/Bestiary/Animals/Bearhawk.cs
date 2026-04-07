using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Animals;

public sealed class Bearhawk : Creature
{
    public Bearhawk()
    {
        Occurrence = Occurrence.Rare;
        Size = Size.Huge;
        PlacesOfOccurrence = TerrainType.Desert | TerrainType.CoastalRegion;

        AttackValue = 145;
        DefenseValue = 170;
        InitiateValue = 50;

        AttacksPerRound = 2;

        HealthPoints = 55;
        PainTolerancePoints = 135;

        AstralMagicResistance = Int32.MaxValue;
        MentalMagicResistance = Int32.MaxValue;
        PoisonResistance = Int32.MaxValue;

        Intelligence = Enums.Intelligence.Low;
        Alignment = Alignment.Death;
        ExperiencePoints = 850;
    }

    [DiceThrow(ThrowType._2D10)]
    [DiceThrowModifier(5)]
    public override int GetDamage() => DiceThrow._2D10() + 5;

    [DiceThrow(ThrowType._1D2)]
    public override int GetNumberAppearing() => DiceThrow._1D2();

    public override List<Speed> Speeds => [new Speed(TravelMode.InTheAir, 160)];
}