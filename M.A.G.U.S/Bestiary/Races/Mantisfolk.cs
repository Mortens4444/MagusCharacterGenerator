using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Races;

public sealed class Mantisfolk : Creature
{
    public Mantisfolk()
    {
        Occurrence = Occurrence.Frequent;
        Size = Size.Human;

        AttackValue = 80;
        DefenseValue = 120;
        InitiateValue = 40;
        AimValue = 30;

        HealthPoints = 18;
        PainTolerancePoints = 56;

        PoisonResistance = 8;
        AstralMagicResistance = 42;
        MentalMagicResistance = 28;

        AttacksPerRound = 4;  // Or 2

        //AttackModes =
        //[
        //    new MeleeAttack(new MantisDoubleSpear(), AttackValue),
        //    new MeleeAttack(new StarDagger(), AttackValue)
        //];

        Intelligence = Enums.Intelligence.Average;
        Alignment = Alignment.Order;
        ExperiencePoints = 850;
    }

    public override string Name => "Mantisfolk";

    [DiceThrow(ThrowType._1D2)]
    public override int GetNumberAppearing() => DiceThrow._1D2();

    [DiceThrow(ThrowType._1D3)]
    public override int GetDamage() => DiceThrow._1D3();

    public override List<Speed> Speeds => [ new Speed(TravelMode.OnLand, 160) ];
}