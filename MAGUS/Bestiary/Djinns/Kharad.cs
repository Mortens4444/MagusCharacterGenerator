using MAGUS.Enums;
using MAGUS.GameSystem;
using MAGUS.GameSystem.Attributes;
using MAGUS.Models;
using MAGUS.Qualifications.Scientific.Psi;
using MAGUS.Things.Weapons.StabbingWeapons;

namespace MAGUS.Bestiary.Djinns;

public sealed class Kharad : DjinnCreature
{
    public Kharad()
    {
        Occurrence = Occurrence.Summoned;
        Alignment = Alignment.Life;
        Size = Size.Human;

        AttackValue = 25;
        DefenseValue = 60;
        InitiateValue = 15;

        AttackModes =
        [
            new MeleeAttack(new Dagger(), AttackValue)
        ];

        HealthPoints = 8;
        PainTolerancePoints = 15;

        AstralMagicResistance = 70;
        MentalMagicResistance = 70;
        PoisonResistance = Int32.MaxValue;

        Psi = new PsiPyarron();
        PsiPoints = 25;
        ManaPoints = 40;

        Intelligence = Enums.Intelligence.High;
        ExperiencePoints = 400;
    }

    [DiceThrow(ThrowType._1D6)]
    public override int GetDamage() => DiceThrow._1D6();

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 100), new Speed(TravelMode.InTheAir, 200)];
}