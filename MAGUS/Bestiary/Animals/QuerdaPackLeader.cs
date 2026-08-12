using MAGUS.Enums;
using MAGUS.GameSystem;
using MAGUS.GameSystem.Attributes;
using MAGUS.Models;
using MAGUS.Things.Weapons;

namespace MAGUS.Bestiary.Animals;

public sealed class QuerdaPackLeader : Creature
{
    public QuerdaPackLeader()
    {
        Occurrence = Occurrence.Rare;
        Size = Size.Big; // 9 arasz
        PlacesOfOccurrence = TerrainType.CursedLand;

        AttackValue = 120;
        DefenseValue = 155;
        InitiateValue = 45;

        HealthPoints = 17;
        PainTolerancePoints = 93;

        AstralMagicResistance = 3;
        PoisonResistance = 8;

        Intelligence = Enums.Intelligence.Animal;
        ExperiencePoints = 320;

        AttackModes =
        [
            new MeleeAttack(new BodyPart("Left claw", ThrowType._1D10), AttackValue),
            new MeleeAttack(new BodyPart("Right claw", ThrowType._1D10), AttackValue),
            new MeleeAttack(new BodyPart("Bite", ThrowType._2D6), AttackValue)
        ];
    }

    public override string Name => "Querda (Khrii'de) pack leader";

    public override string[] Images => ["querda.png"];

    public override double AttacksPerRound => 3;

    [DiceThrow(ThrowType._2D6)]
    public override int GetDamage() => DiceThrow._2D6();

    [DiceThrow(ThrowType._1D6)]
    public override int GetNumberAppearing() => DiceThrow._1D6();

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 140)];
}