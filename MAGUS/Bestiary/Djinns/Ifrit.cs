using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Models;

namespace MAGUS.Bestiary.Djinns;

public sealed class Ifrit : DjinnCreature
{
    public Ifrit()
    {
        Alignment = Alignment.ChaosDeath;

        AttackValue = 80;
        DefenseValue = 120;
        InitiateValue = 100;
        AimValue = 75;

        AttacksPerRound = 2;

        HealthPoints = 15;
        PainTolerancePoints = 50;

        ManaPoints = 75;

        Intelligence = Enums.Intelligence.High;
        ExperiencePoints = 1500;
    }

    [DiceThrow(ThrowType._1D6)]
    public override int GetDamage() => DiceThrow._1D6();

    public override List<Speed> Speeds => [new Speed(TravelMode.InTheAir, 250)];
}