using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Golems;

public sealed class WoodGolem : Creature
{
    public WoodGolem()
    {
        Occurrence = Occurrence.VeryRare;
        Size = Size.Huge;

        AttackValue = 75;
        DefenseValue = 95;
        InitiateValue = 30;

        HealthPoints = 10;

        Intelligence = Enums.Intelligence.None;
        ExperiencePoints = 340;
    }

    public override string Name => "Wood golem";

    [DiceThrow(ThrowType._2D10)]
    [DiceThrowModifier(-2)]
    public override int GetDamage() => DiceThrow._2D10() - 2;

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 75)];
}