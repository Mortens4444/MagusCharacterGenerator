using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Mythical;

public sealed class Manase : Creature
{
    public Manase()
    {
        Occurrence = Occurrence.VeryRare;
        Size = Size.Big;
        Alignment = Alignment.ChaosDeath;

        AttackValue = 110;
        DefenseValue = 140;
        InitiateValue = 38;

        AttacksPerRound = 5;

        HealthPoints = 36;
        PainTolerancePoints = 64;

        PoisonResistance = 8;

        Intelligence = Enums.Intelligence.Low;
        ExperiencePoints = 6000;
    }

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(2)]
    public override int GetDamage() => DiceThrow._1D6() + 2;

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    public override List<Speed> Speeds =>
    [
        new Speed(TravelMode.OnLand, 150)
    ];
}