using MAGUS.Enums;
using MAGUS.GameSystem;
using MAGUS.GameSystem.Attributes;
using MAGUS.Models;
using MAGUS.Things.Weapons;

namespace MAGUS.Bestiary.Animals;

public sealed class WhiteTiger : Creature
{
    public WhiteTiger()
    {
        Occurrence = Occurrence.Rare;
        Size = Size.Human;
        PlacesOfOccurrence = TerrainType.Snowfield;

        AttackValue = 50;
        DefenseValue = 70;
        InitiateValue = 30;

        AttackModes =
        [
            new MeleeAttack(new BodyPart("Weak paw strike", ThrowType._1D5), AttackValue),
            new MeleeAttack(new BodyPart("Powerful paw strike", ThrowType._1D5), AttackValue),
            new MeleeAttack(new BodyPart("Bite", ThrowType._1D10, 2), AttackValue)
        ];

        HealthPoints = 25;
        PainTolerancePoints = 40;

        PoisonResistance = 7;

        Intelligence = Enums.Intelligence.Animal;
        ExperiencePoints = 25;
    }

    public override double AttacksPerRound => 3;

    public override string Name => "White tiger";

    [DiceThrow(ThrowType._1D5)]
    public override int GetDamage() => DiceThrow._1D5();

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 160)];
}
