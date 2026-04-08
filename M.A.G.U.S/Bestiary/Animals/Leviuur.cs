using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Animals;

public sealed class Leviuur : Creature
{
    public Leviuur()
    {
        Occurrence = Occurrence.Rare;
        Size = Size.Small;
        PlacesOfOccurrence = TerrainType.TropicalForest;

        AttackValue = 30;
        DefenseValue = 50;
        InitiateValue = 10;

        HealthPoints = 18;
        PainTolerancePoints = 28;

        AstralMagicResistance = Int32.MaxValue;
        MentalMagicResistance = Int32.MaxValue;
        PoisonResistance = 4;

        Intelligence = Enums.Intelligence.Animal;
        ExperiencePoints = 185;

        // Psi: special
    }

    [DiceThrow(ThrowType._1D6)]
    public override int GetDamage() => DiceThrow._1D6();

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    public override List<Speed> Speeds =>
    [
        new Speed(TravelMode.OnLand, 90)
    ];
}
