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
        MaxHealthPoints = 18;
        HealthPoints = 18;
        MaxPainTolerancePoints = 38;
        PainTolerancePoints = 38;
        PoisonResistance = 4;
        Intelligence = Intelligence.Animal;
        ExperiencePoints = 4;
    }

    [DiceThrow(ThrowType._1K6)]
    public override byte GetDamage() => (byte)DiceThrow._1K6();

    [DiceThrow(ThrowType._2K10)]
    public override byte GetNumberAppearing() => (byte)DiceThrow._2K10();
}
