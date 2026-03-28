using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;
using M.A.G.U.S.Qualifications.Scientific.Psi;

namespace M.A.G.U.S.Bestiary.Djinns;

public sealed class Huri : DjinnCreature
{
    public Huri()
    {
        Occurrence = Occurrence.Summoned;
        Alignment = Alignment.Life;
        Size = Size.Human;

        AttackValue = 25;
        DefenseValue = 60;
        InitiateValue = 15;

        HealthPoints = 8;
        PainTolerancePoints = 15;

        AstralMagicResistance = 70;
        MentalMagicResistance = 70;
        PoisonResistance = Int32.MaxValue;

        Psi = new PsiPyarron();
        PsiPoints = 25;
        ManaPoints = 30;

        Intelligence = Enums.Intelligence.High;
        ExperiencePoints = 400;
    }

    [DiceThrow(ThrowType._1D3)]
    public override int GetDamage() => DiceThrow._1D3();

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 100), new Speed(TravelMode.InTheAir, 200)];
}