using MAGUS.Enums;
using MAGUS.GameSystem;
using MAGUS.GameSystem.Attributes;
using MAGUS.Models;
using MAGUS.Things.Armors;
using MAGUS.Things.Weapons;

namespace MAGUS.Bestiary.Animals;

public sealed class GrizzlyBear : Creature
{
    public GrizzlyBear()
    {
        Occurrence = Occurrence.Frequent;
        PlacesOfOccurrence = TerrainType.ArcticForest;

        Armor = new NaturalArmor(1);
        Size = Size.Big;

        AttackValue = 70;
        DefenseValue = 90;
        InitiateValue = 20;
        AttackModes =
        [
            new MeleeAttack(new BodyPart("Left paw strike", ThrowType._1D6, 2), AttackValue),
            new MeleeAttack(new BodyPart("Right paw strike", ThrowType._1D6, 2), AttackValue),
            new MeleeAttack(new BodyPart("Bite", ThrowType._1D6), AttackValue)
        ];

        HealthPoints = 45;
        PainTolerancePoints = 90;

        PoisonResistance = 8;
        Intelligence = Enums.Intelligence.Animal;
        ExperiencePoints = 80;
    }

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(2)]
    public override int GetDamage() => DiceThrow._1D6() + 2;

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    public override double AttacksPerRound => 3;

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 50)];

    public override string Name => "Grizzly bear";

    public override string[] Sounds => ["bear_growl"];
}
