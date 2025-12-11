using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;

namespace M.A.G.U.S.Bestiary.Animals;

public sealed class GrayDolphin : Creature
{
    public GrayDolphin()
    {
        Occurrence = Occurrence.Frequent;
        Intelligence = Enums.Intelligence.High;
        Size = Size._1_5_meters;
        Speed = 160;
        AttackValue = 40;
        DefenseValue = 80;
        InitiatingValue = 20;
        HealthPoints = 15;
        PainTolerancePoints = 30;
        AstralMagicResistance = 3;
        MentalMagicResistance = 3;
        PoisonResistance = 4;
        ExperiencePoints = 0;
        Alignment = Enums.Alignment.Life;
    }

    public override string Name => "Gray dolphin";

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(2)]
    public override int GetDamage() => DiceThrow._1D6() + 2;

    [DiceThrow(ThrowType._2D6)]
    public override int GetNumberAppearing() => DiceThrow._2D6();
}
