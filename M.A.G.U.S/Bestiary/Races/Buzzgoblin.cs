using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;
using M.A.G.U.S.Things.Weapons.RangedWeapons;
using M.A.G.U.S.Things.Weapons.Spears;
using M.A.G.U.S.Things.Weapons.StabbingWeapons;

namespace M.A.G.U.S.Bestiary.Races;

public sealed class Buzzgoblin : Creature
{
    public Buzzgoblin()
    {
        Occurrence = Occurrence.Frequent;
        Size = Size.Small;

        AttackValue = 45;
        DefenseValue = 80;
        InitiateValue = 5;
        AimValue = 0;

        AttackModes =
        [
            new MeleeAttack(new Spear(), AttackValue),
            new MeleeAttack(new Knife(), AttackValue),
            new RangedAttack(new Blowpipe(), AimValue),
            new RangedAttack(new Shortbow(), AimValue)
        ];

        HealthPoints = 3;
        PainTolerancePoints = 11;

        PoisonResistance = 1;
        AstralMagicResistance = 0;
        MentalMagicResistance = 0;

        Intelligence = Enums.Intelligence.Average;

        ExperiencePoints = 7;

        Alignment = Alignment.Chaos;
    }

    public override string Name => "Buzzgoblin";

    [DiceThrow(ThrowType._1D100)]
    public override int GetNumberAppearing() => DiceThrow._1D100();

    [DiceThrow(ThrowType._1D2)]
    public override int GetDamage() => DiceThrow._1D2();

    public override List<Speed> Speeds =>
    [
        new Speed(TravelMode.OnLand, 70)
    ];
}