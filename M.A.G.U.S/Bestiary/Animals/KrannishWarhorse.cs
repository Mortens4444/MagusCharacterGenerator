using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;
using M.A.G.U.S.Things.Weapons;
using Mtf.Extensions.Services;

namespace M.A.G.U.S.Bestiary.Animals;

public sealed class KrannishWarhorse : Creature
{
    public KrannishWarhorse()
    {
        Occurrence = Occurrence.Rare;
        Size = Size.Big;
        PlacesOfOccurrence = TerrainType.Anywhere;
        Country = GameSystem.Places.Country.Kran;

        AttackValue = 50;
        DefenseValue = 70;
        InitiateValue = 9;

        var rangeAttacks = new[]
        {
            new RangedAttack(new BreathWeapon("Fire breath", ThrowType._1D6), AimValue),
            new RangedAttack(new BreathWeapon("Poison breath", ThrowType._3D6), AimValue),
            new RangedAttack(new BreathWeapon("Flash breath", ThrowType._1D6), AimValue)
        };
        var rangeAttackSelector = RandomProvider.GetSecureRandomInt(0, 3);

        AttackModes =
        [
            new MeleeAttack(new BodyPart("Left forehoof", ThrowType._1D10), AttackValue),
            new MeleeAttack(new BodyPart("Right forehoof", ThrowType._1D10), AttackValue),
            new MeleeAttack(new BodyPart("Bite", ThrowType._1D10, 1), AttackValue),
            new MeleeAttack(new BodyPart("Fisting", ThrowType._2D6, 1), AttackValue),
            rangeAttacks[rangeAttackSelector]
        ];

        HealthPoints = 40;
        PainTolerancePoints = 70;

        PoisonResistance = Int32.MaxValue;

        Intelligence = Enums.Intelligence.Low;
        ExperiencePoints = 80;

        // AstralMagicResistance = special
    }

    public override string Name => "Krannish Warhorse";

    public override double AttacksPerRound => 3;

    [DiceThrow(ThrowType._1D10)]
    [DiceThrowModifier(1)]
    public override int GetDamage() => DiceThrow._1D10() + 1;

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1; // Variable

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 110)];
}