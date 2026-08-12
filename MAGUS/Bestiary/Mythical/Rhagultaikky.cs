using MAGUS.Enums;
using MAGUS.GameSystem;
using MAGUS.GameSystem.Attributes;
using MAGUS.Models;
using MAGUS.Things.Weapons;

namespace MAGUS.Bestiary.Mythical;

public sealed class Rhagultaikky : Creature
{
    public Rhagultaikky()
    {
        Occurrence = Occurrence.Rare;
        Size = Size.Big;
        PlacesOfOccurrence = TerrainType.SouthernSnowfield;

        AttackValue = 125;
        DefenseValue = 180;
        InitiateValue = 65;

        HealthPoints = 20;
        PainTolerancePoints = 75;

        AstralMagicResistance = Int32.MaxValue;
        MentalMagicResistance = Int32.MaxValue;
        PoisonResistance = 6;

        Intelligence = Enums.Intelligence.Low;
        ExperiencePoints = 1650;

        AttackModes =
        [
            new MeleeAttack(new BodyPart("Left claw", ThrowType._1D6), AttackValue),
            new MeleeAttack(new BodyPart("Right claw", ThrowType._1D6), AttackValue)
        ];
    }

    public override double AttacksPerRound => 2;

    [DiceThrow(ThrowType._1D6)]
    public override int GetDamage() => DiceThrow._1D6();

    [DiceThrow(ThrowType._1D4)]
    public override int GetNumberAppearing() => DiceThrow._1D4();

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 120)];

    public override string[] Sounds => ["yeti-roar"];
}