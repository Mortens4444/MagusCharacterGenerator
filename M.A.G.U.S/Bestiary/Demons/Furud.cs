using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;
using M.A.G.U.S.Things.Weapons;

namespace M.A.G.U.S.Bestiary.Demons;

public sealed class Furud : Creature
{
    public Furud()
    {
        Occurrence = Occurrence.Summoned;
        PlacesOfOccurrence = TerrainType.Anywhere;
        Size = Size.Big;

        AttackValue = 110;
        DefenseValue = 160;
        InitiateValue = 70;

        AttacksPerRound = 3;

        HealthPoints = 20;
        PainTolerancePoints = 60;

        PoisonResistance = Int32.MaxValue;
        AstralMagicResistance = Int32.MaxValue;
        MentalMagicResistance = Int32.MaxValue;

        Intelligence = Enums.Intelligence.High;
        Alignment = Alignment.ChaosDeath;

        ExperiencePoints = 2500;

        AttackModes =
        [
            new MeleeAttack(new BodyPart("Bite", ThrowType._3D10), AttackValue),
            new MeleeAttack(new BodyPart("Claw (left)", ThrowType._2D6), AttackValue),
            new MeleeAttack(new BodyPart("Claw (right)", ThrowType._2D6), AttackValue)
        ];
    }

    public override string Name => "Furud (The Hunter)";

    public override string[] Images => ["furud.png"];

    [DiceThrow(ThrowType._3D10)]
    public override int GetDamage() => DiceThrow._3D10();

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 300)];
}