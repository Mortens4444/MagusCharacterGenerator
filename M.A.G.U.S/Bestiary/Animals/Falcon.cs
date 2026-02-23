using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Animals;

public sealed class Falcon : Creature
{
    public Falcon()
    {
        Occurrence = Occurrence.Frequent;
        Intelligence = Enums.Intelligence.Animal;
        Size = Size.Small;
        InitiateValue = 12;
        AttackValue = 30;
        DefenseValue = 90;
        HealthPoints = 4;
        PainTolerancePoints = 7;
        PoisonResistance = 3;
        ExperiencePoints = 1;
    }

    [DiceThrow(ThrowType._1D2)]
    public override int GetDamage() => DiceThrow._1D2();


    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    public override List<Speed> Speeds => [new Speed(TravelMode.InTheAir, 180), new Speed(TravelMode.OnLand, 5)];
}
