using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Animals;

public sealed class Malhohaury : Creature
{
    public Malhohaury()
    {
        Occurrence = Occurrence.VeryRare;
        Size = Size.Big;
        Country = GameSystem.Places.Country.Sheral;
        PlacesOfOccurrence = TerrainType.Mountains;

        AttackValue = 90;
        DefenseValue = 100;
        InitiateValue = 20;

        HealthPoints = 15;
        PainTolerancePoints = 48;

        AstralMagicResistance = Int32.MaxValue;
        MentalMagicResistance = Int32.MaxValue;
        PoisonResistance = Int32.MaxValue;

        Intelligence = Enums.Intelligence.Low;
        ExperiencePoints = 350;
    }

    [DiceThrow(ThrowType._3D10)]
    public override int GetDamage() => DiceThrow._3D10(); // From charge

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 120)];
}