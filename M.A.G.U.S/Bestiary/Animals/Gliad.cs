using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Animals;

public sealed class Gliad : Creature
{
    public Gliad()
    {
        Occurrence = Occurrence.Rare;
        Size = Size.Small;

        AttackValue = 25;
        DefenseValue = 50;
        InitiateValue = 9;

        HealthPoints = 4;
        PainTolerancePoints = 10;

        PoisonResistance = 12;

        Intelligence = Enums.Intelligence.High;
        Alignment = Alignment.Life;
        ExperiencePoints = 8;
    }

    public override double AttacksPerRound => 2;

    [DiceThrow(ThrowType._1D6)]
    public override int GetDamage() => DiceThrow._1D6();

    [DiceThrow(ThrowType._2D10)]
    public override int GetNumberAppearing() => DiceThrow._2D10();

    public override List<Speed> Speeds =>
    [
        new Speed(TravelMode.OnLand, 120),
        new Speed(TravelMode.OnWalls, 60)
    ];
}