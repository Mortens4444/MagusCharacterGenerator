using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;

namespace M.A.G.U.S.Bestiary.Animals;

public sealed class Wolf : Creature
{
    public Wolf()
    {
        Occurrence = Occurrence.Frequent;
        Size = Size.Human;
        Speed = 120;
        AttackValue = 35;
        DefenseValue = 60;
        InitiatingValue = 10;
        HealthPoints = 18;
        PainTolerancePoints = 38;
        PoisonResistance = 4;
        Intelligence = Enums.Intelligence.Animal;
        ExperiencePoints = 4;
    }

    [DiceThrow(ThrowType._1D6)]
    public override int GetDamage() => DiceThrow._1D6();

    [DiceThrow(ThrowType._2D10)]
    public override int GetNumberAppearing() => DiceThrow._2D10();
}
