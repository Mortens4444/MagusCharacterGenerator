using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;
using M.A.G.U.S.Things.Weapons.RangedWeapons;
using M.A.G.U.S.Things.Weapons.StabbingWeapons;

namespace M.A.G.U.S.Bestiary.Races;

public sealed class ShiKris : Creature
{
    public ShiKris()
    {
        Occurrence = Occurrence.Rare;
        Size = Size.Human;

        AttackValue = 35;
        DefenseValue = 80;
        InitiateValue = 25;
        AimValue = 0;

        AttackModes =
        [
            new MeleeAttack(new ShortSword(), AttackValue),
            new MeleeAttack(new Longsword(), AttackValue),
            new RangedAttack(new Shortbow(), AimValue),
            new RangedAttack(new Longbow(), AimValue)
        ];

        HealthPoints = 10;
        PainTolerancePoints = 40;

        PoisonResistance = Int32.MaxValue;
        AstralMagicResistance = 45;
        MentalMagicResistance = 45;

        Intelligence = Enums.Intelligence.High;

        Alignment = Alignment.ChaosDeath;

        ExperiencePoints = 0; // változó (forma függő)
    }

    public override string Name => "Shi-kris";

    [DiceThrow(ThrowType._1D10)]
    public override int GetNumberAppearing() => DiceThrow._1D10();

    [DiceThrow(ThrowType._1D10)]
    public override int GetDamage() => DiceThrow._1D10();

    public override List<Speed> Speeds =>
    [
        new Speed(TravelMode.OnLand, 100)
    ];
}