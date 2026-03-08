using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Animals;

public sealed class Gider : Creature
{
    public Gider()
    {
        Occurrence = Occurrence.Frequent;
        Size = Size.Small;
        PlacesOfOccurrence = TerrainType.Cave;

        AttackValue = 25;
        DefenseValue = 55;
        InitiateValue = 10;

        HealthPoints = 4;
        PainTolerancePoints = 12;

        PoisonResistance = 3;

        Intelligence = Enums.Intelligence.Animal;

        ExperiencePoints = 2;
    }

    [DiceThrow(ThrowType._3D10)]
    public override int GetNumberAppearing() => DiceThrow._3D10();

    [DiceThrow(ThrowType._1D6)]
    public override int GetDamage() => DiceThrow._1D6();

    public override List<Speed> Speeds => [new Speed(TravelMode.InTheAir, 50)];
}