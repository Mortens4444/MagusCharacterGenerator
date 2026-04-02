using M.A.G.U.S.Enums;
using M.A.G.U.S.Extensions;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Animals;

public sealed class WolfPackLeader : Creature
{
    public WolfPackLeader()
    {
        Occurrence = Occurrence.Frequent;
        Size = Size.Small;
        PlacesOfOccurrence = TerrainType.ArcticForest | TerrainType.TemperateForest;

        AttackValue = 40;
        DefenseValue = 65;
        InitiateValue = 10;

        HealthPoints = 20;
        PainTolerancePoints = 42;

        PoisonResistance = 4;

        Intelligence = Enums.Intelligence.Animal;
        ExperiencePoints = 4;
    }

    public override string Name => "Wolf pack leader";

    [DiceThrow(ThrowType._1D6)]
    public override int GetDamage() => DiceThrow._1D6();

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 120)];

    public override string[] Sounds => ["wolf"];
}
