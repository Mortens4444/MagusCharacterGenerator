using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;
using M.A.G.U.S.Qualifications.Scientific.Psi;

namespace M.A.G.U.S.Bestiary.Djinns;

public sealed class Karaa : DjinnCreature
{
    public Karaa()
    {
        Occurrence = Occurrence.Rare;
        Alignment = Alignment.Life;
        Size = Size.Human;

        AttackValue = 140;
        DefenseValue = 180;
        InitiateValue = 70;
        AimValue = 50;

        AttacksPerRound = 2;

        HealthPoints = 18;
        PainTolerancePoints = 65;

        AstralMagicResistance = 170;
        MentalMagicResistance = 170;
        PoisonResistance = Int32.MaxValue;

        Psi = new PsiPyarron();
        PsiPoints = 100;
        ManaPoints = 90;

        Intelligence = Enums.Intelligence.High;
        ExperiencePoints = 20000;
    }

    [DiceThrow(ThrowType._2D6)]
    [DiceThrowModifier(8)]
    public override int GetDamage() => DiceThrow._2D6() + 8;

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    public override List<Speed> Speeds =>
    [
        new Speed(TravelMode.OnLand, 140),
        new Speed(TravelMode.InTheAir, 220)
    ];
}