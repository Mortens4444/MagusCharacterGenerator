using MAGUS.Enums;
using MAGUS.GameSystem;
using MAGUS.GameSystem.Attributes;
using MAGUS.Models;
using MAGUS.Qualifications.Scientific.Psi;
using MAGUS.Things.Weapons.RangedWeapons;
using MAGUS.Things.Weapons.StabbingWeapons;

namespace MAGUS.Bestiary.Races;

public sealed class Mongrel : Creature
{
    public Mongrel()
    {
        Occurrence = Occurrence.Rare;
        Size = Size.Human;
        PlacesOfOccurrence = TerrainType.Anywhere;
        Country = GameSystem.Places.Country.Ediomad;

        AttackValue = 70;  // Változó
        DefenseValue = 110; // Változó
        InitiateValue = 35;
        AimValue = 50;

        AttackModes =
        [
            new RangedAttack(new KahreiCrossbow(), AimValue),
            new MeleeAttack(new Broadsword(), AttackValue),
            new MeleeAttack(new Dagger(), AttackValue)
        ];

        HealthPoints = 12;
        PainTolerancePoints = 30; // változó (vért nélkül max. 30)

        AttacksPerRound = 2;
        PoisonResistance = Int32.MaxValue;
        AstralMagicResistance = Int32.MaxValue;
        MentalMagicResistance = Int32.MaxValue;

        MinIntelligence = Enums.Intelligence.Low;
        MaxIntelligence = Enums.Intelligence.Outstanding;

        ExperiencePoints = 100; // Változó

        Alignment = Alignment.ChaosDeath;

        Psi = new PsiAntientWay();
        PsiPoints = 30;
    }

    public override string Name => "Mongrel (Ochak Va'Maadad)";

    public override string[] Images => ["mongrel.png"];

    [DiceThrow(ThrowType._1D6)]
    public override int GetNumberAppearing() => DiceThrow._1D6();

    [DiceThrow(ThrowType._1D6)]
    public override int GetDamage() => DiceThrow._1D6();

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 100)];
}