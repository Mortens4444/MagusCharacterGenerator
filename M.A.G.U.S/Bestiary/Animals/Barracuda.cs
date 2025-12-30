using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;
using M.A.G.U.S.Things.Weapons;

namespace M.A.G.U.S.Bestiary.Animals;

public sealed class Barracuda : Creature
{
    public Barracuda()
    {
        Occurrence = Occurrence.Frequent;
        Size = Size.Big;
        AttackValue = 100;
        DefenseValue = 150;
        InitiateValue = 40;
        AttackModes =
        [
            new MeleeAttack(new BodyPart("Bite", ThrowType._1D10), AttackValue)
        ];
        HealthPoints = 5;
        PainTolerancePoints = 20;
        PoisonResistance = 5;
        Intelligence = Enums.Intelligence.Animal;
        ExperiencePoints = 15;
    }

    public override string Name => "Barracuda, the sea wolf";

    public override string[] Images => ["barracuda.png"];

    [DiceThrow(ThrowType._1D10)]
    public override int GetDamage() => DiceThrow._1D10();

    [DiceThrow(ThrowType._2D10)]
    public override int GetNumberAppearing() => DiceThrow._2D10();

    public override List<Speed> Speeds => [new Speed(TravelMode.InWater, 125)];
}
