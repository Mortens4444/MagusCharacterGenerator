using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Golems;

public sealed class StoneGolem : Creature
{
    public StoneGolem()
    {
        Occurrence = Occurrence.VeryRare;
        Size = Size.Huge;
        PlacesOfOccurrence = TerrainType.Anywhere;

        AttackValue = 75;
        DefenseValue = 95;
        InitiateValue = 20;

        HealthPoints = 21;

        Intelligence = Enums.Intelligence.None;
        ExperiencePoints = 680;
    }

    public override string Name => "Stone golem";

    [DiceThrow(ThrowType._2D10)]
    public override int GetDamage() => DiceThrow._2D10();

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 50)];
}