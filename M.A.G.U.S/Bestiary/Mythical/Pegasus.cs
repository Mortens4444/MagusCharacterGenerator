using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;
using M.A.G.U.S.Things.Weapons;

namespace M.A.G.U.S.Bestiary.Mythical;

public sealed class Pegasus : Creature
{
    public Pegasus()
    {
        Occurrence = Occurrence.VeryRare;
        Size = Size.Huge;
        PlacesOfOccurrence = TerrainType.Mountains | TerrainType.Plains | TerrainType.Grassland | TerrainType.CoastalRegion;

        AttackValue = 85;
        DefenseValue = 90;
        InitiateValue = 35;

        AttackModes =
        [
            new MeleeAttack(new BodyPart("Left forehoof", ThrowType._1D10), AttackValue),
            new MeleeAttack(new BodyPart("Right forehoof", ThrowType._1D10), AttackValue),
            new MeleeAttack(new BodyPart("Bite", ThrowType._1D6), AttackValue)
        ];

        HealthPoints = 28;
        PainTolerancePoints = 50;

        AstralMagicResistance = 12;
        MentalMagicResistance = 14;
        PoisonResistance = 4;

        Intelligence = Enums.Intelligence.Average;
        Alignment = Alignment.Life;
        ExperiencePoints = 30;
    }

    [DiceThrow(ThrowType._1D10)]
    public override int GetDamage() => DiceThrow._1D10();

    [DiceThrow(ThrowType._1D2)]
    public override int GetNumberAppearing() => DiceThrow._1D2();

    public override double AttacksPerRound => 3;

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 150), new Speed(TravelMode.InTheAir, 300)];
}