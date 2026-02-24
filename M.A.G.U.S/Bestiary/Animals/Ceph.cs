using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Animals;

public sealed class Ceph : Creature
{
    public Ceph()
    {
        Occurrence = Occurrence.Rare;
        Size = Size.Big;

        AttackValue = 66;
        DefenseValue = 90;
        InitiateValue = 10;
        AimValue = 0;

        AttacksPerRound = 2;

        HealthPoints = 20;
        PainTolerancePoints = 100;

        PoisonResistance = 7;
        AstralMagicResistance = 0;
        MentalMagicResistance = 0;

        Intelligence = Enums.Intelligence.Animal;

        ExperiencePoints = 25;
    }

    public override int GetNumberAppearing() => 1;

    [DiceThrow(ThrowType._1D10)]
    public override int GetDamage() => DiceThrow._1D10();

    public override List<Speed> Speeds => [new Speed(TravelMode.Underground, 30)];
}