using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Races;

public sealed class MosQuin : Creature
{
    public MosQuin()
    {
        Occurrence = Occurrence.VeryRare;
        Size = Size.Human;
        AttackValue = 80;
        DefenseValue = 130;
        InitiateValue = 55;
        AimValue = 0;
        HealthPoints = 18;
        PainTolerancePoints = 75;
        PoisonResistance = 10;
        AstralMagicResistance = 110;
        MentalMagicResistance = 110;
        AttacksPerRound = 2;
        Intelligence = Enums.Intelligence.Outstanding;
        Alignment = Alignment.ChaosDeath;
        ManaPoints = 100;
        ExperiencePoints = 20000;
    }

    [DiceThrow(ThrowType._1D6)]
    public override int GetDamage() => DiceThrow._1D6();

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    public override string Name => "Mos-quin";

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 70)];
}
