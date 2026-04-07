using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Races;

public sealed class Tamari : Creature
{
    public Tamari()
    {
        Occurrence = Occurrence.Rare;
        Size = Size.Human;
        PlacesOfOccurrence = TerrainType.DeepUnderground;

        AttackValue = 75;
        DefenseValue = 115;
        InitiateValue = 35;
        AimValue = 25;

        HealthPoints = 12;
        PainTolerancePoints = 55;

        AstralMagicResistance = 20;
        MentalMagicResistance = 15;
        PoisonResistance = 5;

        Intelligence = Enums.Intelligence.High;
        Alignment = Alignment.Chaos;
        ExperiencePoints = 175;
    }

    [DiceThrow(ThrowType._1D3)]
    public override int GetNumberAppearing() => DiceThrow._1D3();

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(2)]
    public override int GetDamage() => DiceThrow._1D6() + 2;

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 130)];
}