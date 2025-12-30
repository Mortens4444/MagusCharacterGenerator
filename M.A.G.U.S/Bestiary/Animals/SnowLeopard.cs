using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;
using M.A.G.U.S.Things.Weapons;

namespace M.A.G.U.S.Bestiary.Animals;

public sealed class SnowLeopard : Creature
{
    public SnowLeopard()
    {
        Occurrence = Occurrence.Rare;
        Size = Size.WithersHeight_1_20_meter;
        AttackValue = 90;
        DefenseValue = 140;
        InitiateValue = 65;
        AttackModes =
        [
            new MeleeAttack(new BodyPart("Weak paw strike", ThrowType._1D6, 3), AttackValue),
            new MeleeAttack(new BodyPart("Powerful paw strike", ThrowType._1D6, 3), AttackValue),
            new MeleeAttack(new BodyPart("Bite", ThrowType._1D10, 2), AttackValue),
            new MeleeAttack(new BodyPart("Run past and slash with claws", ThrowType._2D10, 1), AttackValue) // Only 1 attack is allowed with this method
        ];

        HealthPoints = 25;
        PainTolerancePoints = 43;
        PoisonResistance = 9;
        Intelligence = Enums.Intelligence.Low;
        ExperiencePoints = 350;
    }

    public override double AttacksPerRound => 4;

    public override string Name => "Snow leopard";

    [DiceThrow(ThrowType._1D5)]
    public override int GetDamage() => DiceThrow._1D5();

    public override int GetNumberAppearing() => 2;

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 160)];
}
