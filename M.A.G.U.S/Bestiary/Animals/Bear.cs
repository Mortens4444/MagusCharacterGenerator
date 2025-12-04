using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;

namespace M.A.G.U.S.Bestiary.Animals;

public sealed class Bear : Creature
{
    public Bear()
    {
        Occurrence = Occurrence.Frequent;
        Size = Size.Big;
        Speed = 50;
        AttackValue = 70;
        DefenseValue = 60;
        InitiatingValue = 5;
        AttacksPerRound = 3;
        HealthPoints = 38;
        PainTolerancePoints = 80;
        PoisonResistance = 8;
        Intelligence = Intelligence.Animal;
        ExperiencePoints = 50;
    }

    [DiceThrow(ThrowType._1D10)]
    [DiceThrowModifier(2)]
    public override byte GetDamage() => (byte)(DiceThrow._1D10() + 2);

    [DiceThrow(ThrowType._1D2)]
    public override byte GetNumberAppearing() => (byte)DiceThrow._1D2();
}
