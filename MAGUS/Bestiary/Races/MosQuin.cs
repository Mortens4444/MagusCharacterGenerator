using MAGUS.Enums;
using MAGUS.GameSystem;
using MAGUS.GameSystem.Attributes;
using MAGUS.Models;

namespace MAGUS.Bestiary.Races;

public sealed class MosQuin : Creature
{
    public MosQuin()
    {
        Occurrence = Occurrence.VeryRare;
        Size = Size.Human;
        PlacesOfOccurrence = TerrainType.Anywhere;
        Country = GameSystem.Places.Country.Kran;

        AttackValue = 80;
        DefenseValue = 130;
        InitiateValue = 55;
        AimValue = 0;

        HealthPoints = 18;
        PainTolerancePoints = 75;

        PoisonResistance = 10;
        AstralMagicResistance = 110;
        MentalMagicResistance = 110;

        AttacksPerRound = 2;

        ManaPoints = 100;

        Intelligence = Enums.Intelligence.Outstanding;
        Alignment = Alignment.ChaosDeath;
        ExperiencePoints = 20000;
    }

    [DiceThrow(ThrowType._1D6)]
    public override int GetDamage() => DiceThrow._1D6();

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    public override string Name => "Mos-quin";

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 70)];
}
