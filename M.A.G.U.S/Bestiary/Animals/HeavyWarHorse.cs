using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;
using M.A.G.U.S.Things.Weapons;

namespace M.A.G.U.S.Bestiary.Animals;

public sealed class HeavyWarHorse : Creature
{
    public HeavyWarHorse()
    {
        Occurrence = Occurrence.Frequent;
        Size = Size.Big;

        AttackValue = 35;
        DefenseValue = 55;
        InitiateValue = 8;

        AttackModes =
        [
            new MeleeAttack(new BodyPart("Bite", ThrowType._1D6), AttackValue),
            new MeleeAttack(new BodyPart("Front hoof strike", ThrowType._1D5), AttackValue),
            new MeleeAttack(new BodyPart("Rear hoof strike", ThrowType._1D5), AttackValue)
        ];

        HealthPoints = 35;
        PainTolerancePoints = 70;

        PoisonResistance = 4;

        Intelligence = Enums.Intelligence.Animal;
        ExperiencePoints = 30;
    }

    public override string Name => "Heavy war horse";

    public override string[] Images => ["horse_heavy_war.png"];

    public override double AttacksPerRound => 3;

    [DiceThrow(ThrowType._1D6)]
    public override int GetDamage() => DiceThrow._1D6();

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 90)];
}