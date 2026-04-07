using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Golems;

public sealed class IronGolem : Creature
{
    public IronGolem()
    {
        Occurrence = Occurrence.VeryRare;
        Size = Size.Huge;
        PlacesOfOccurrence = TerrainType.Anywhere;

        AttackValue = 85;
        DefenseValue = 105;
        InitiateValue = 20;

        HealthPoints = 41;

        Intelligence = Enums.Intelligence.None;
        ExperiencePoints = 1020;
    }

    public override string Name => "Iron golem";

    [DiceThrow(ThrowType._2D10)]
    public override int GetDamage() => DiceThrow._2D10();

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 50)];
}