using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Fey;

public sealed class ForestSprite : Creature
{
    public ForestSprite()
    {
        Occurrence = Occurrence.VeryRare;
        Size = Size.Small;
        PlacesOfOccurrence = TerrainType.TemperateForest;

        AttackValue = 15;
        DefenseValue = 120;
        InitiateValue = 40;
        AimValue = 60;

        HealthPoints = 1;
        PainTolerancePoints = 3;

        AstralMagicResistance = 20;
        MentalMagicResistance = 20;
        PoisonResistance = 4;

        Intelligence = Enums.Intelligence.Average;
        Alignment = Alignment.Life;
        ExperiencePoints = 1;
    }

    public override string Name => "Forest sprite";

    [DiceThrow(ThrowType._2D6)]
    public override int GetNumberAppearing() => DiceThrow._2D6();

    [DiceThrowModifier(0)]
    public override int GetDamage() => 0; // + DreamOintment poison

    public override List<Speed> Speeds =>
    [
        new Speed(TravelMode.OnLand, 12),
        new Speed(TravelMode.InTheAir, 50)
    ];
}