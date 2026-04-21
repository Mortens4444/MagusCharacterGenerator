using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;
using M.A.G.U.S.Things.Weapons;

namespace M.A.G.U.S.Bestiary.Animals;

public sealed class LightWarHorse : Creature
{
    public LightWarHorse()
    {
        Occurrence = Occurrence.Frequent;
        Size = Size.Big;

        AttackValue = 25;
        DefenseValue = 65;
        InitiateValue = 10;

        AttackModes =
        [
            new MeleeAttack(new BodyPart("Bite", ThrowType._1D5), AttackValue),
            new MeleeAttack(new BodyPart("Front hoof strike", ThrowType._1D5), AttackValue),
            new MeleeAttack(new BodyPart("Rear hoof strike", ThrowType._1D5), AttackValue)
        ];

        HealthPoints = 28;
        PainTolerancePoints = 50;

        PoisonResistance = 3;

        Intelligence = Enums.Intelligence.Animal;
        ExperiencePoints = 20;
    }

    public override string Name => "Light war horse";

    public override string[] Images => ["horse_light_war.png"];
    
    public override double AttacksPerRound => 3;

    [DiceThrow(ThrowType._1D5)]
    public override int GetDamage() => DiceThrow._1D5();

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 150)];
}