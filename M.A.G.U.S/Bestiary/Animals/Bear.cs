using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Things.Weapons;

namespace M.A.G.U.S.Bestiary.Animals;

public sealed class Bear : Creature
{
    public Bear()
    {
        Occurrence = Occurrence.Frequent;
        Size = Size.Big;
        Speed = 50;
        AttackValue = 70;
        DefenseValue = 60;
        InitiatingValue = 5;
        AttacksPerRound = 3;
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
}
