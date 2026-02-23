using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Races;

public sealed class GhoRagg : Creature
{
    public GhoRagg()
    {
        Occurrence = Occurrence.VeryRare;
        Size = Size.Human;
        AttackValue = 90;
        DefenseValue = 150;
        InitiateValue = 40;
        AimValue = 0;
        AttacksPerRound = 2;
        HealthPoints = 20;
        PainTolerancePoints = 80;
        PoisonResistance = 7;
        AstralMagicResistance = 50;
        MentalMagicResistance = 50;
        Intelligence = Enums.Intelligence.Average;
        Alignment = Alignment.ChaosDeath;
        ExperiencePoints = 750;
    }

    [DiceThrow(ThrowType._1D10)]
    [DiceThrowModifier(4)]
    public override int GetDamage() => DiceThrow._1D10() + 4;

    [DiceThrow(ThrowType._5D10)]
    public override int GetNumberAppearing() => DiceThrow._5D10();

    public override string Name => "Gho-ragg";

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 110)];
}
