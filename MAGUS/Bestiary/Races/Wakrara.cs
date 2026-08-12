using MAGUS.Enums;
using MAGUS.GameSystem;
using MAGUS.GameSystem.Attributes;
using MAGUS.Models;
using MAGUS.Qualifications.Scientific.Psi;
using MAGUS.Things.Weapons;

namespace MAGUS.Bestiary.Races;

public sealed class Wakrara : Creature
{
    public Wakrara()
    {
        Occurrence = Occurrence.VeryRare;
        Size = Size.Huge;
        PlacesOfOccurrence = TerrainType.Mountains | TerrainType.InnerTerritory;
        Country = GameSystem.Places.Country.Kran;

        AttackValue = 120;
        DefenseValue = 155;
        InitiateValue = 40;
        AimValue = 35;

        AttackModes =
        [
            new MeleeAttack(new BodyPart("Left hand", ThrowType._3D6, 4), AttackValue),
            new MeleeAttack(new BodyPart("Right hand", ThrowType._3D6, 4), AttackValue)
        ];

        HealthPoints = 45;
        PainTolerancePoints = 90;

        AstralMagicResistance = Int32.MaxValue;
        MentalMagicResistance = Int32.MaxValue;
        PoisonResistance = Int32.MaxValue;

        Psi = new PsiPyarron();
        PsiPoints = 100;
        ManaPoints = 300; // 3 * 100

        Intelligence = Enums.Intelligence.High;
        Alignment = Alignment.ChaosDeath;
        ExperiencePoints = 18000;
    }

    public override double AttacksPerRound => 2;

    [DiceThrow(ThrowType._3D6)]
    [DiceThrowModifier(4)]
    public override int GetDamage() => DiceThrow._3D6() + 4;

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 90)];
}