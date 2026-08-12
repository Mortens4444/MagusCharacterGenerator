using MAGUS.Enums;
using MAGUS.GameSystem;
using MAGUS.GameSystem.Attributes;
using MAGUS.Models;
using MAGUS.Things.Armors;
using MAGUS.Things.Weapons;

namespace MAGUS.Bestiary.Animals;

public sealed class Bear : Creature
{
    public Bear()
    {
        Armor = new NaturalArmor(1);
        Occurrence = Occurrence.Frequent;
        PlacesOfOccurrence = TerrainType.ArcticForest | TerrainType.TemperateForest;
        Size = Size.Big;

        AttackValue = 70;
        DefenseValue = 60;
        InitiateValue = 5;

        AttackModes =
        [
            new MeleeAttack(new BodyPart("Left paw strike", ThrowType._1D10, 2), AttackValue),
            new MeleeAttack(new BodyPart("Right paw strike", ThrowType._1D10, 2), AttackValue),
            new MeleeAttack(new BodyPart("Bite", ThrowType._1D6), AttackValue)
        ];

        HealthPoints = 38;
        PainTolerancePoints = 80;

        PoisonResistance = 8;

        Intelligence = Enums.Intelligence.Animal;
        ExperiencePoints = 50;
    }

    [DiceThrow(ThrowType._1D10)]
    [DiceThrowModifier(2)]
    public override int GetDamage() => DiceThrow._1D10() + 2;

    [DiceThrow(ThrowType._1D2)]
    public override int GetNumberAppearing() => DiceThrow._1D2();

    public override double AttacksPerRound => 3;

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 50)];

    public override string[] Sounds => ["bear_growl"];
}
