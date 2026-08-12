using MAGUS.Enums;
using MAGUS.GameSystem;
using MAGUS.GameSystem.Attributes;
using MAGUS.Models;
using MAGUS.Things.Weapons;

namespace MAGUS.Bestiary.Mythical;

public sealed class Iblogh : Creature
{
    public Iblogh()
    {
        Occurrence = Occurrence.VeryRare;
        PlacesOfOccurrence = TerrainType.DeepUnderground;

        AttackValue = 70;
        DefenseValue = 118;
        InitiateValue = 20;
        AimValue = 40;

        AttackModes =
        [
            new MeleeAttack(new BodyPart("Left claw", ThrowType._1D6), AttackValue),
            new MeleeAttack(new BodyPart("Right claw", ThrowType._1D6), AttackValue),
            new RangedAttack(new BreathWeapon("Spit", ThrowType._1D6), AimValue)
        ];

        HealthPoints = 39;
        PainTolerancePoints = 120;

        AstralMagicResistance = 70;
        MentalMagicResistance = 70;

        Intelligence = Enums.Intelligence.Low;
        ExperiencePoints = 880;
    }

    public override string Name => "Iblogh (The Cellar Beast)";

    public override string[] Images => ["iblogh.png"];

    public override double AttacksPerRound => 3;

    [DiceThrow(ThrowType._1D6)]
    public override int GetDamage() => DiceThrow._1D6();

    [DiceThrow(ThrowType._1D3)]
    public override int GetNumberAppearing() => DiceThrow._1D3();

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 120)];
}