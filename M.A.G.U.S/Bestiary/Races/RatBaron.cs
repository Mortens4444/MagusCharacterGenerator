using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;
using M.A.G.U.S.Things.Weapons.StabbingWeapons;

namespace M.A.G.U.S.Bestiary.Races;

public sealed class RatBaron : Creature
{
    public RatBaron()
    {
        Occurrence = Occurrence.Frequent;
        Size = Size.Small;
        PlacesOfOccurrence = TerrainType.Urban | TerrainType.Sewer | TerrainType.Underground | TerrainType.OldDilapidatedBuilding | TerrainType.InnerTerritory;

        AttackValue = 45;
        DefenseValue = 85;
        InitiateValue = 15;
        AimValue = 5;

        AttackModes =
        [
            new MeleeAttack(new ShortSword(), AttackValue)
        ];

        HealthPoints = 5;
        PainTolerancePoints = 20;

        AstralMagicResistance = 1;
        MentalMagicResistance = 1;
        PoisonResistance = 3;

        Intelligence = Enums.Intelligence.Low;
        Alignment = Alignment.Neutral;
        ExperiencePoints = 13;
    }

    public override string Name => "Rat baron";

    [DiceThrow(ThrowType._1D6)]
    public override int GetDamage() => DiceThrow._1D6();

    [DiceThrow(ThrowType._2D6)]
    public override int GetNumberAppearing() => DiceThrow._2D6();

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 80)];
}