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
        HealthPoints = 24;
        PainTolerancePoints = 32;
        AstralMagicResistance = 0;
        MentalMagicResistance = 0;
        PoisonResistance = 7;
        ExperiencePoints = 580;
    }

    [DiceThrow(ThrowType._2D10)]
    public override int GetDamage() => DiceThrow._2D10();


    [DiceThrow(ThrowType._1D6)]
    public override int GetNumberAppearing() => DiceThrow._1D6();
}
