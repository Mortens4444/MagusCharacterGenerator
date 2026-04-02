using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;
using M.A.G.U.S.Things.Weapons;

namespace M.A.G.U.S.Bestiary.Mythical;

public sealed class Wywern : Creature
{
    public Wywern()
    {
        Occurrence = Occurrence.Rare;
        Size = Size.Big; // 3.5 m hosszú
        PlacesOfOccurrence = TerrainType.Mountains;

        AttackValue = 65;
        DefenseValue = 95;
        InitiateValue = 28;

        AttackModes =
        [
            new MeleeAttack(new BodyPart("Left claw", ThrowType._1D10), AttackValue),
            new MeleeAttack(new BodyPart("Right claw", ThrowType._1D10), AttackValue),
            new MeleeAttack(new BodyPart("Bite", ThrowType._1D6), AttackValue)
        ];

        HealthPoints = 38;
        PainTolerancePoints = 78;

        PoisonResistance = 8;

        Intelligence = Enums.Intelligence.Animal;
        ExperiencePoints = 230;
    }

    public override double AttacksPerRound => 3;

    [DiceThrow(ThrowType._1D10)]
    public override int GetDamage() => DiceThrow._1D10();

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1; // fészken 2-5)

    public override List<Speed> Speeds => [new Speed(TravelMode.InTheAir, 140), new Speed(TravelMode.OnLand, 25)];
}