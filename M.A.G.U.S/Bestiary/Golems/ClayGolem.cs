using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Golems;

public sealed class ClayGolem : Creature
{
    public ClayGolem()
    {
        Occurrence = Occurrence.VeryRare;
        Size = Size.Huge;
        PlacesOfOccurrence = TerrainType.Anywhere;

        AttackValue = 75;
        DefenseValue = 95;
        InitiateValue = 10;

        HealthPoints = 21;

        Intelligence = Enums.Intelligence.None;
        ExperiencePoints = 510;
    }

    public override string Name => "Clay golem";

    [DiceThrow(ThrowType._2D10)]
    [DiceThrowModifier(-2)]
    public override int GetDamage() => DiceThrow._2D10() - 2;

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 25)];
}