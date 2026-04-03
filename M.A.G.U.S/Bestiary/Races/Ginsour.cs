using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Races;

public abstract class Ginsour : Creature
{
    protected Ginsour()
    {
        Occurrence = Occurrence.VeryRare;
        Size = Size.Small;

        AttackValue = 50;
        DefenseValue = 95;
        InitiateValue = 30;
        AimValue = 90;

        HealthPoints = 6;
        PainTolerancePoints = 18;

        AstralMagicResistance = 35;
        MentalMagicResistance = 25;
        PoisonResistance = 10;

        Intelligence = Enums.Intelligence.Average;
        Alignment = Alignment.LifeChaos;
    }

    [DiceThrow(ThrowType._1D5)]
    public override int GetDamage() => DiceThrow._1D5();

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 80)];
}
