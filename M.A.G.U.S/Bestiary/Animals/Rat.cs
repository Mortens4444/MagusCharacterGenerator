using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Animals;

public sealed class Rat : Creature
{
    public Rat()
    {
        Occurrence = Occurrence.Frequent;
        Size = Size.Small;
        AttackValue = 20;
        DefenseValue = 40;
        InitiateValue = 10;
        HealthPoints = 4;
        PainTolerancePoints = 8;
        PoisonResistance = 8;
        Intelligence = Enums.Intelligence.Animal;
        ExperiencePoints = 1;
    }

    [DiceThrowModifier(1)]
    public override int GetDamage() => 1;

    [DiceThrow(ThrowType._1D100)]
    public override int GetNumberAppearing() => DiceThrow._1D100();

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 60), new Speed(TravelMode.InWater, 12)];
}
