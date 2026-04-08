using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Races;

public sealed class FlameRunner : Creature
{
    public FlameRunner()
    {
        Occurrence = Occurrence.VeryRare;
        Size = Size.Small;
        PlacesOfOccurrence = TerrainType.Forest;

        HealthPoints = 1;
        PainTolerancePoints = 3;

        AstralMagicResistance = Int32.MaxValue;
        MentalMagicResistance = Int32.MaxValue;
        PoisonResistance = Int32.MaxValue;

        Intelligence = Enums.Intelligence.Low;
        ExperiencePoints = 100;
    }

    public override string Name => "Flame runner";

    [DiceThrowModifier(0)]
    public override int GetDamage() => 0;

    [DiceThrow(ThrowType._1D2)]
    public override int GetNumberAppearing() => DiceThrow._1D2(); // Sometimes 1D6 by description.

    public override List<Speed> Speeds =>
    [
        new Speed(TravelMode.InTheAir, 380)
    ];
}