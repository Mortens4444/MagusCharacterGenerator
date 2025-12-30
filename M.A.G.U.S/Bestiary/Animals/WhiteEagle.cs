using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Animals;

public sealed class WhiteEagle : Creature
{
    public WhiteEagle()
    {
        Occurrence = Occurrence.Frequent;
        Size = Size.Human;
        InitiateValue = 15;
        AttackValue = 50;
        DefenseValue = 90;
        HealthPoints = 5;
        PainTolerancePoints = 10;
        PoisonResistance = 4;
        Intelligence = Enums.Intelligence.Animal;
        ExperiencePoints = 2;
    }

    public override string Name => "White eagle";

    [DiceThrow(ThrowType._1D3)]
    public override int GetDamage() => DiceThrow._1D3();

    [DiceThrow(ThrowType._1D2)]
    public override int GetNumberAppearing() => DiceThrow._1D2();

    public override List<Speed> Speeds => [new Speed(TravelMode.InTheAir, 175)];
}
