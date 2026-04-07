using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Magical;

public sealed class ApeHyena : Creature
{
    public ApeHyena()
    {
        Occurrence = Occurrence.VeryRare;
        Size = Size.Big;
        Alignment = Alignment.Death;
        PlacesOfOccurrence = TerrainType.Desert;

        AttackValue = 125;
        DefenseValue = 165;
        InitiateValue = 45;

        AttacksPerRound = 3;

        HealthPoints = 48;
        PainTolerancePoints = 140;

        AstralMagicResistance = Int32.MaxValue;
        MentalMagicResistance = Int32.MaxValue;
        PoisonResistance = 10;

        Intelligence = Enums.Intelligence.Average;
        ExperiencePoints = 12500;
    }

    public override string Name => "Ape hyena";

    [DiceThrow(ThrowType._2D10)]
    public override int GetDamage() => DiceThrow._2D10();

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    public override List<Speed> Speeds =>
    [
        new Speed(TravelMode.OnLand, 300)
    ];
}