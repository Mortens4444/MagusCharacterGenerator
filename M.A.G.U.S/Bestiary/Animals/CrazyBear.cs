using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;
using M.A.G.U.S.Things.Weapons;

namespace M.A.G.U.S.Bestiary.Animals;

public sealed class CrazyBear : Creature
{
    public CrazyBear()
    {
        Occurrence = Occurrence.VeryRare;
        Size = Size.Big;
        AttackValue = 80;
        DefenseValue = 90;
        InitiateValue = 25;
        AttackModes =
        [
            new MeleeAttack(new BodyPart("Left paw strike", ThrowType._2D6, 2), AttackValue),
            new MeleeAttack(new BodyPart("Right paw strike", ThrowType._2D6, 2), AttackValue),
            new MeleeAttack(new BodyPart("Bite", ThrowType._1D10), AttackValue)
        ];
        HealthPoints = 45;
        PainTolerancePoints = 110;
        PoisonResistance = 9;
        Intelligence = Enums.Intelligence.Animal;
        ExperiencePoints = 200;
    }

    [DiceThrow(ThrowType._2D6)]
    [DiceThrowModifier(2)]
    public override int GetDamage() => DiceThrow._2D6() + 2;

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    public override double AttacksPerRound => 3;

    public override string Name => "Crazy bear";

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 50)];

    public override string[] Sounds => ["bear_growl"];
}
