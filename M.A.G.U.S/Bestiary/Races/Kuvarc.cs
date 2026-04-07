using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Races;

public sealed class Kuvarc : Creature
{
    public Kuvarc()
    {
        Occurrence = Occurrence.VeryRare;
        Size = Size.Huge;

        AttackValue = 60;
        DefenseValue = 104;
        InitiateValue = 10;

        HealthPoints = 20;

        AstralMagicResistance = Int32.MaxValue;
        MentalMagicResistance = 64;
        PoisonResistance = Int32.MaxValue;

        Intelligence = Enums.Intelligence.Average;
        Alignment = Alignment.Order;
        ExperiencePoints = 265;
    }

    [DiceThrow(ThrowType._2D6)]
    public override int GetDamage() => DiceThrow._2D6(); // + special

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 50)];
}