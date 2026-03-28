using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;
using M.A.G.U.S.Qualifications.Scientific.Psi;
using M.A.G.U.S.Things.Weapons.StabbingWeapons;

namespace M.A.G.U.S.Bestiary.Djinns;

public sealed class Jahrend : DjinnCreature
{
    public Jahrend()
    {
        Occurrence = Occurrence.Summoned;
        Alignment = Alignment.Life;
        Size = Size.Human;

        AttackValue = 100;
        DefenseValue = 160;
        InitiateValue = 60;
        AimValue = 30;

        AttacksPerRound = 2;

        AttackModes =
        [
            new MeleeAttack(new Yatagan(), AttackValue),
            new MeleeAttack(new Yatagan(), AttackValue)
        ];

        HealthPoints = 12;
        PainTolerancePoints = 22;

        AstralMagicResistance = 95;
        MentalMagicResistance = 95;
        PoisonResistance = Int32.MaxValue;

        Psi = new PsiPyarron();
        PsiPoints = 30;
        ManaPoints = 50;

        Intelligence = Enums.Intelligence.High;
        ExperiencePoints = 1250;
    }

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(6)]
    public override int GetDamage() => DiceThrow._1D6() + 6;

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 120), new Speed(TravelMode.InTheAir, 180)];
}