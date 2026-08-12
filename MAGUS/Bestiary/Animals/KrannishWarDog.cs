using MAGUS.Enums;
using MAGUS.GameSystem;
using MAGUS.GameSystem.Attributes;
using MAGUS.Models;
using MAGUS.Things.Weapons;

namespace MAGUS.Bestiary.Animals;

public sealed class KrannishWarDog : Creature
{
    public KrannishWarDog()
    {
        Occurrence = Occurrence.Rare;
        Size = Size.Huge;
        Country = GameSystem.Places.Country.Kran;
        PlacesOfOccurrence = TerrainType.Anywhere;

        AttackValue = 90;
        DefenseValue = 120;
        InitiateValue = 30;

        AttackModes =
        [
            new MeleeAttack(new BodyPart("Left claw", ThrowType._1D6, 1), AttackValue),
            new MeleeAttack(new BodyPart("Right claw", ThrowType._1D6, 1), AttackValue),
            new MeleeAttack(new BodyPart("Bite", ThrowType._1D10, 1), AttackValue)
        ];

        HealthPoints = 25;
        PainTolerancePoints = 85;

        AstralMagicResistance = Int32.MaxValue;
        MentalMagicResistance = Int32.MaxValue;
        PoisonResistance = 15;

        Intelligence = Enums.Intelligence.Animal;
        Alignment = Alignment.ChaosDeath;
        ExperiencePoints = 255;

        // Psi = special
    }

    public override string Name => "Krannish War Dog";

    public override double AttacksPerRound => 3;

    [DiceThrow(ThrowType._1D10)]
    [DiceThrowModifier(1)]
    public override int GetDamage() => DiceThrow._1D10() + 1;

    [DiceThrow(ThrowType._1D6)]
    public override int GetNumberAppearing() => DiceThrow._1D6();

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 125)];
}

