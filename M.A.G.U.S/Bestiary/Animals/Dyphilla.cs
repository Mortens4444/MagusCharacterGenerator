using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Animals;

public sealed class Dyphilla : Creature
{
    public Dyphilla()
    {
        Occurrence = Occurrence.Rare;
        Size = Size.Small;
        PlacesOfOccurrence = TerrainType.Cave | TerrainType.DeepUnderground;

        AttackValue = 46;
        DefenseValue = 105;
        InitiateValue = 32;

        HealthPoints = 4;
        PainTolerancePoints = 12;

        AstralMagicResistance = 1;
        MentalMagicResistance = 1;
        PoisonResistance = 5;

        Intelligence = Enums.Intelligence.Low;
        ExperiencePoints = 12;
    }

    [DiceThrow(ThrowType._1D6)]
    public override int GetDamage() => DiceThrow._1D6();

    [DiceThrow(ThrowType._1D2)]
    public override int GetNumberAppearing() => DiceThrow._1D2();

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 40), new Speed(TravelMode.InTheAir, 100)];

    //public override string[] Sounds => ["bat_screech", "bat_swarm"];
}