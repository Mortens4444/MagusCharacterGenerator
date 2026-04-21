using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Mythical;

public sealed class Mahrahadi : Creature
{
    public Mahrahadi()
    {
        Occurrence = Occurrence.VeryRare;
        Size = Size.Small;
        Alignment = Alignment.Death;
        Country = GameSystem.Places.Country.TabaElIbara;
        PlacesOfOccurrence = TerrainType.Desert;

        DefenseValue = 0;
        InitiateValue = 120;
        AimValue = 100;

        AttacksPerRound = 2;

        HealthPoints = 10;
        PainTolerancePoints = 26;

        AstralMagicResistance = Int32.MaxValue;
        MentalMagicResistance = Int32.MaxValue;
        PoisonResistance = Int32.MaxValue;

        Intelligence = Enums.Intelligence.High;
        ExperiencePoints = 2750;

        // ManaPoints = special;
        // No direct damage value specified.
    }

    [DiceThrowModifier(0)]
    public override int GetDamage() => 0;

    [DiceThrow(ThrowType._1D2)]
    public override int GetNumberAppearing() => DiceThrow._1D2();

    public override List<Speed> Speeds => [new Speed(TravelMode.InTheAir, 100)];
}
