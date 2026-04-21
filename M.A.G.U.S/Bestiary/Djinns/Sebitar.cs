using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;
using M.A.G.U.S.Qualifications.Scientific.Psi;

namespace M.A.G.U.S.Bestiary.Djinns;

public sealed class Sebitar : DjinnCreature
{
    public Sebitar()
    {
        Occurrence = Occurrence.Rare;
        Alignment = Alignment.Life;
        Size = Size.Human;

        AttackValue = 45;
        DefenseValue = 90;
        InitiateValue = 95;
        AimValue = 50;

        AttacksPerRound = 1;

        HealthPoints = 14;
        PainTolerancePoints = 35;

        AstralMagicResistance = 170;
        MentalMagicResistance = 170;
        PoisonResistance = Int32.MaxValue;

        Psi = new PsiPyarron();
        PsiPoints = 100;
        ManaPoints = 100;

        Intelligence = Enums.Intelligence.High;
        ExperiencePoints = 17000;
    }

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(6)]
    public override int GetDamage() => DiceThrow._1D6() + 6;

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 140), new Speed(TravelMode.InTheAir, 200)];
}