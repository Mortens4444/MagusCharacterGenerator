using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;
using M.A.G.U.S.Things.Weapons;

namespace M.A.G.U.S.Bestiary.Animals;

public sealed class ElvenHound : Creature
{
    public ElvenHound()
    {
        Occurrence = Occurrence.Rare;
        Size = Size.Small;
        PlacesOfOccurrence = TerrainType.TemperateForest;

        AttackValue = 30;
        DefenseValue = 55;
        InitiateValue = 10;
        AimValue = 0;

        AttackModes =
        [
            new MeleeAttack(new BodyPart("Bite", ThrowType._1D6), AttackValue)
        ];

        HealthPoints = 16;
        PainTolerancePoints = 34;

        AstralMagicResistance = 6;
        MentalMagicResistance = 3;
        PoisonResistance = 3;

        Intelligence = Enums.Intelligence.Low;
        Alignment = Alignment.Life;
        ExperiencePoints = 7;
    }

    public override string Name => "Elven hound";

    [DiceThrow(ThrowType._1D6)]
    public override int GetDamage() => DiceThrow._1D6();

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 130), new Speed(TravelMode.InWater, 25)];
}