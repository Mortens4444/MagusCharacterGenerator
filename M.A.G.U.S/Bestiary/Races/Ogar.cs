using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Races;

public sealed class Ogar : Creature
{
    public Ogar()
    {
        Occurrence = Occurrence.Frequent;
        Size = Size.Huge;

        AttackValue = 90;
        DefenseValue = 110;
        InitiateValue = 29;

        HealthPoints = 25;
        PainTolerancePoints = 90;

        AstralMagicResistance = 20;
        MentalMagicResistance = 20;
        PoisonResistance = 9;

        Intelligence = Enums.Intelligence.Average;
        Alignment = Alignment.ChaosDeath;
        ExperiencePoints = 160;
    }

    [DiceThrow(ThrowType._2D10)]
    [DiceThrowModifier(4)]
    public override int GetDamage() => DiceThrow._2D10() + 4;

    [DiceThrow(ThrowType._2D40)]
    public override int GetNumberAppearing() => DiceThrow._2D40();

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 75)];
}
