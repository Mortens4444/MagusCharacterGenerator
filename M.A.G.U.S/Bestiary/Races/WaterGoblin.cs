using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Races;

public sealed class WaterGoblin : Creature
{
    public WaterGoblin()
    {
        Occurrence = Occurrence.Rare;
        Size = Size.Small;
        PlacesOfOccurrence = TerrainType.Lake;

        AttackValue = 40;
        DefenseValue = 75;
        InitiateValue = 5;
        AimValue = 15;

        HealthPoints = 5;
        PainTolerancePoints = 15;

        AstralMagicResistance = 150;
        MentalMagicResistance = 150;
        PoisonResistance = Int32.MaxValue;

        ManaPoints = 70;

        Intelligence = Enums.Intelligence.High;
        Alignment = Alignment.Chaos;
        ExperiencePoints = 600;
    }

    public override string Name => "Water goblin";

    [DiceThrow(ThrowType._1D6)]
    public override int GetDamage() => DiceThrow._1D6();

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    public override List<Speed> Speeds => [new Speed(TravelMode.InWater, 150), new Speed(TravelMode.OnLand, 35)];
}