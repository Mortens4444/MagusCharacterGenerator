using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;
using M.A.G.U.S.Things.Weapons;

namespace M.A.G.U.S.Bestiary.Animals;

public sealed class GrizzlyBear : Creature
{
    public GrizzlyBear()
    {
        Occurrence = Occurrence.Frequent;
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
