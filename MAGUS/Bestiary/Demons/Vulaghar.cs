using MAGUS.Enums;
using MAGUS.GameSystem;
using MAGUS.GameSystem.Attributes;
using MAGUS.Models;
using MAGUS.Things.Weapons;

namespace MAGUS.Bestiary.Demons;

public sealed class Vulaghar : Creature
{
    public Vulaghar()
    {
        Occurrence = Occurrence.Rare;
        Size = Size.Human;
        PlacesOfOccurrence = TerrainType.Anywhere;

        AttackValue = 85;
        DefenseValue = 120;
        InitiateValue = 35;

        AttackModes =
        [
            new MeleeAttack(new BodyPart("First strike", ThrowType._1D6), AttackValue),
            new MeleeAttack(new BodyPart("Second strike", ThrowType._1D6), AttackValue),
            new MeleeAttack(new BodyPart("Bite", ThrowType._1D10), AttackValue)
        ];

        HealthPoints = 15;

        Intelligence = Enums.Intelligence.High;
        Alignment = Alignment.Death;
        ExperiencePoints = 1000; // Változó
    }

    public override double AttacksPerRound => 3;

    public override string Name => "Vulaghar (the dark wanderer)";

    public override string[] Images => ["shrabtistt.png"];

    [DiceThrow(ThrowType._1D10)]
    public override int GetDamage() => DiceThrow._1D10();

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 100)];
}