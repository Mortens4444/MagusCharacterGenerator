using M.A.G.U.S.Bestiary;
using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Races;

public sealed class Rochalea : Creature
{
    public Rochalea()
    {
        Occurrence = Occurrence.VeryRare;
        Size = Size.Big;

        AttackValue = 80;
        DefenseValue = 120;
        InitiateValue = 25;

        AttacksPerRound = 2;

        HealthPoints = 16;
        PainTolerancePoints = 60;

        AstralMagicResistance = 35;
        MentalMagicResistance = 35;
        PoisonResistance = 7;

        Intelligence = Enums.Intelligence.Low;
        Alignment = Alignment.Chaos;
        ExperiencePoints = 600;
    }

    [DiceThrow(ThrowType._1D10)]
    [DiceThrowModifier(2)]
    public override int GetDamage() => DiceThrow._1D10() + 2;

    [DiceThrow(ThrowType._1D2)]
    public override int GetNumberAppearing() => DiceThrow._1D2();

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 90)];
}