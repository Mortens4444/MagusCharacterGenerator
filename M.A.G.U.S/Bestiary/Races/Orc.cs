using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;

namespace M.A.G.U.S.Bestiary.Races;

public sealed class Orc : Creature
{
    public Orc()
    {
        Occurrence = Occurrence.Frequent;
        Size = Size.Human;
        Speed = 100;
        AttackValue = 55;
        DefenseValue = 85;
        InitiatingValue = 20;
        AimingValue = 0;
        HealthPoints = 10;
        PainTolerancePoints = 16;
        PoisonResistance = 3;
        Intelligence = Intelligence.Low;
        Alignment = Enums.Alignment.Chaos;
        ExperiencePoints = 30;
    }

    [DiceThrow(ThrowType._1D10)]
    public override byte GetDamage() => (byte)(DiceThrow._1D10());

    [DiceThrow(ThrowType._10D10)]
    public override byte GetNumberAppearing() => DiceThrow._10D10();
}
