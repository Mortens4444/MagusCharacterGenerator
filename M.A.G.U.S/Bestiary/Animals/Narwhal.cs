using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;

namespace M.A.G.U.S.Bestiary.Animals;

public sealed class Narwhal : Creature
{
    public Narwhal()
    {
        Occurrence = Occurrence.Rare;
        Intelligence = Intelligence.Animal;
        Size = Size._4_meters;
        Speed = 220;
        AttackValue = 150;
        DefenseValue = 170;
        MaxHealthPoints = 24;
        HealthPoints = 24;
        MaxPainTolerancePoints = 32;
        PainTolerancePoints = 32;
        AstralMagicResistance = 0;
        MentalMagicResistance = 0;
        PoisonResistance = 7;
        ExperiencePoints = 580;
    }

    [DiceThrow(ThrowType._2K10)]
    public override byte GetDamage() => (byte)(DiceThrow._2K10());


    [DiceThrow(ThrowType._1K6)]
    public override byte GetNumberAppearing() => (byte)DiceThrow._1K6();
}
