using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Magical;

public sealed class Lathran : Creature
{
    public Lathran()
    {
        Occurrence = Occurrence.VeryRare;
        Size = Size.Small;
        PlacesOfOccurrence = TerrainType.Anywhere;

        AttackValue = 25;
        DefenseValue = 80;
        InitiateValue = 30;

        HealthPoints = 2;
        PainTolerancePoints = 6;

        AstralMagicResistance = 25;
        MentalMagicResistance = 25;
        PoisonResistance = 5;

        Intelligence = Enums.Intelligence.Animal;

        ExperiencePoints = 2;
    }

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    [DiceThrow(ThrowType._1D2)]
    public override int GetDamage() => DiceThrow._1D2();

    public override List<Speed> Speeds =>
    [
        new Speed(TravelMode.OnLand, 100),
        new Speed(TravelMode.InTheAir, 140)
    ];
}