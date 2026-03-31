using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;
using M.A.G.U.S.Things.Weapons;

namespace M.A.G.U.S.Bestiary.Demons;

public sealed class Vulaghar : Creature
{
    public Vulaghar() // Shrabtistt
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

    [DiceThrow(ThrowType._1D10)]
    public override int GetDamage() => DiceThrow._1D10();

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 100)];
}