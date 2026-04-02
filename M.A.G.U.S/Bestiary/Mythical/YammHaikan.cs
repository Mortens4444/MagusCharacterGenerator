using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;
using M.A.G.U.S.Things.Weapons;

namespace M.A.G.U.S.Bestiary.Mythical;

public sealed class YammHaikan : Creature
{
    public YammHaikan()
    {
        Occurrence = Occurrence.Rare;
        PlacesOfOccurrence = TerrainType.SaltWater | TerrainType.CoastalIsland;
        Size = Size.Huge;

        AttackValue = 90;
        DefenseValue = 120;
        InitiateValue = 45;
        AimValue = 35;

        AttackModes =
        [
            new MeleeAttack(new BodyPart("Left hand", ThrowType._1D6), AttackValue),
            new MeleeAttack(new BodyPart("Right hand", ThrowType._1D6), AttackValue),
            new MeleeAttack(new BodyPart("Bite", ThrowType._1D6), AttackValue)
        ];

        HealthPoints = 25;
        PainTolerancePoints = 45;

        AstralMagicResistance = Int32.MaxValue;
        MentalMagicResistance = Int32.MaxValue;
        PoisonResistance = Int32.MaxValue;

        Intelligence = Enums.Intelligence.High;
        ManaPoints = 110;
        Alignment = Alignment.ChaosDeath;
        ExperiencePoints = 11500;
    }

    [DiceThrow(ThrowType._1D6)]
    public override int GetDamage() => DiceThrow._1D6();

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    public override string Name => "Yamm-haikan";

    public override double AttacksPerRound => 3;

    public override List<Speed> Speeds => [new Speed(TravelMode.InWater, 75)];
}