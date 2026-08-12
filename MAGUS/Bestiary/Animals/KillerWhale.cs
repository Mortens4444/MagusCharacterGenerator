using MAGUS.Enums;
using MAGUS.GameSystem;
using MAGUS.GameSystem.Attributes;
using MAGUS.Models;

namespace MAGUS.Bestiary.Animals;

public sealed class KillerWhale : Creature
{
    public KillerWhale()
    {
        Occurrence = Occurrence.Rare;
        Size = Size._4_meters;
        PlacesOfOccurrence = TerrainType.SaltWater;

        InitiateValue = 5;
        AttackValue = 95;
        DefenseValue = 70;

        HealthPoints = 30;
        PainTolerancePoints = 68;

        AstralMagicResistance = 0;
        MentalMagicResistance = 0;
        PoisonResistance = 8;

        Intelligence = Enums.Intelligence.Average;
        ExperiencePoints = 20;
    }

    public override string Name => "Killer whale";

    [DiceThrow(ThrowType._3D10)]
    public override int GetDamage() => DiceThrow._3D10();


    [DiceThrow(ThrowType._1D6)]
    public override int GetNumberAppearing() => DiceThrow._1D6();

    public override List<Speed> Speeds => [new Speed(TravelMode.InWater, 120)];
}
