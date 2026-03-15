using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;
using M.A.G.U.S.Things.Weapons;

namespace M.A.G.U.S.Bestiary.Animals;

public sealed class Nganga : Creature
{
    public Nganga()
    {
        Occurrence = Occurrence.Rare;
        Size = Size.Big;

        PlacesOfOccurrence = TerrainType.Jungle | TerrainType.TropicalForest;

        AttackValue = 95;
        DefenseValue = 120;
        InitiateValue = 15;

        AttackModes =
        [
            new MeleeAttack(new BodyPart("Left fist", ThrowType._1D10, 4), AttackValue),
            new MeleeAttack(new BodyPart("Right fist", ThrowType._1D10, 4), AttackValue),
            new MeleeAttack(new BodyPart("Bite", ThrowType._1D6), AttackValue)
        ];

        HealthPoints = 35;
        PainTolerancePoints = 70;

        PoisonResistance = 6;

        AstralMagicResistance = 0;
        MentalMagicResistance = 0;

        Intelligence = Enums.Intelligence.Low;

        ExperiencePoints = 200;
    }

    [DiceThrow(ThrowType._2D10)]
    public override int GetNumberAppearing() => DiceThrow._2D10();

    [DiceThrow(ThrowType._1D10)]
    [DiceThrowModifier(4)]
    public override int GetDamage() => DiceThrow._1D10() + 4;

    public override double AttacksPerRound => 3;

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 80)];
}