using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;

namespace M.A.G.U.S.Bestiary.Races;

public sealed class Goblin : Creature
{
    public Goblin()
    {
        Occurrence = Occurrence.Rare;
        Size = Size.Small;
        Speed = 65;
        AttackValue = 25;
        DefenseValue = 60;
        InitiatingValue = 10;
        AimingValue = 0;
        HealthPoints = 7;
        PainTolerancePoints = 12;
        PoisonResistance = 3;
        Intelligence = Intelligence.Low;
        Alignment = Enums.Alignment.Chaos;
        ExperiencePoints = 10;
    }

    [DiceThrow(ThrowType._1D6)]
    public override byte GetDamage() => (byte)(DiceThrow._1D6());

    [DiceThrow(ThrowType._10D10)]
    public override byte GetNumberAppearing() => (byte)DiceThrow._10D10();
}
