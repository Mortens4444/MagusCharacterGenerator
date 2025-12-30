using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Animals;

public sealed class Bat : Creature
{
    public Bat()
    {
        Occurrence = Occurrence.Frequent;
        Size = Size.Small;
        InitiateValue = 20;
        AttackValue = 20;
        DefenseValue = 92;
        HealthPoints = 2;
        PainTolerancePoints = 5;
        PoisonResistance = 3;
        Intelligence = Enums.Intelligence.Animal;
        ExperiencePoints = 1;
    }

    public override int GetDamage() => 1;

    [DiceThrow(ThrowType._2D10)]
    public override int GetNumberAppearing() => DiceThrow._2D10();

    public override List<Speed> Speeds => [new Speed(TravelMode.InTheAir, 120), new Speed(TravelMode.OnLand, 30)];
}
