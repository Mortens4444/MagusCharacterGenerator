using MAGUS.Enums;
using MAGUS.GameSystem;
using MAGUS.GameSystem.Attributes;
using MAGUS.Models;
using MAGUS.Things.Weapons;

namespace MAGUS.Bestiary.Animals;

public sealed class Rukh : Creature
{
    public Rukh()
    {
        Occurrence = Occurrence.Rare;
        Size = Size.Big;

        PlacesOfOccurrence = TerrainType.Mountains | TerrainType.Forest;

        AttackValue = 75;
        DefenseValue = 110;
        InitiateValue = 32;

        AttackModes =
        [
            new MeleeAttack(new BodyPart("Claw", ThrowType._1D6), AttackValue),
            new MeleeAttack(new BodyPart("Beak", ThrowType._1D10), AttackValue)
        ];

        HealthPoints = 28;
        PainTolerancePoints = 48;

        PoisonResistance = 4;

        Intelligence = Enums.Intelligence.Animal;

        ExperiencePoints = 35;
    }

    [DiceThrow(ThrowType._1D10)]
    public override int GetDamage() => DiceThrow._1D10();

    [DiceThrow(ThrowType._1D2)]
    public override int GetNumberAppearing() => DiceThrow._1D2();

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 40), new Speed(TravelMode.InTheAir, 200)];
}