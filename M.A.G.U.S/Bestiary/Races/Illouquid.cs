using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;
using M.A.G.U.S.Things.Weapons.Spears;

namespace M.A.G.U.S.Bestiary.Races;

public sealed class Illouquid : Creature
{
    public Illouquid()
    {
        Occurrence = Occurrence.Frequent;
        Size = Size.Human;
        PlacesOfOccurrence = TerrainType.Swamp;

        AttackValue = 30;
        DefenseValue = 76;
        InitiateValue = 24;
        AimValue = 20;

        AttackModes =
        [
            new MeleeAttack(new Harpoon(), AttackValue)
            //new MeleeAttack(new BodyPart("Harpoon", ThrowType._1D10), AttackValue)
        ];

        HealthPoints = 6;
        PainTolerancePoints = 14;

        AstralMagicResistance = 2;
        MentalMagicResistance = 1;
        PoisonResistance = 9;

        Intelligence = Enums.Intelligence.Average;
        Alignment = Alignment.Chaos;
        ExperiencePoints = 30;
    }

    public override string[] Images => ["illouquid.png"];

    public override double AttacksPerRound => 1;

    [DiceThrow(ThrowType._1D10)]
    public override int GetDamage() => DiceThrow._1D10();

    [DiceThrow(ThrowType._2D6)]
    public override int GetNumberAppearing() => DiceThrow._2D6();

    public override List<Speed> Speeds =>
    [
        new Speed(TravelMode.OnLand, 90),
        new Speed(TravelMode.InWater, 80)
    ];
}