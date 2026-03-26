using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Djinns;

public sealed class Marid : DjinnCreature
{
    public Marid()
    {
        Alignment = Alignment.ChaosDeath;

        AttackValue = 150;
        DefenseValue = 190;
        InitiateValue = 95;

        AttacksPerRound = 2;

        HealthPoints = 50;
        PainTolerancePoints = 200;

        Intelligence = Enums.Intelligence.High;
        ExperiencePoints = 14000;
    }

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(10)]
    public override int GetDamage() => DiceThrow._1D6() + 10;

    public override List<Speed> Speeds => [new Speed(TravelMode.InTheAir, 200)];
}