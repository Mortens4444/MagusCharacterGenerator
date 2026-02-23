using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;
using M.A.G.U.S.Things.Weapons.RangedWeapons;
using M.A.G.U.S.Things.Weapons.StabbingWeapons;

namespace M.A.G.U.S.Bestiary.Races;

public sealed class SaQuad : Creature
{
    public SaQuad()
    {
        Occurrence = Occurrence.VeryRare;
        Size = Size.Human;

        AttackValue = 75;
        DefenseValue = 125;
        InitiateValue = 25;
        AimValue = 0;

        AttackModes =
        [
            new MeleeAttack(new ShortSword(), AttackValue),
            new MeleeAttack(new Longsword(), AttackValue),
            new RangedAttack(new Shortbow(), AimValue),
            new RangedAttack(new Longbow(), AimValue)
        ];

        HealthPoints = 30;
        PainTolerancePoints = 95;

        PoisonResistance = 10;
        AstralMagicResistance = 90;
        MentalMagicResistance = 90;

        Intelligence = Enums.Intelligence.Outstanding;

        ExperiencePoints = 35000;

        Alignment = Alignment.ChaosLife;
        //ManaPoints = 0; // változó – papként számolandó
    }

    public override string Name => "Sa-quad";

    [DiceThrow(ThrowType._1D4)]
    public override int GetNumberAppearing() => DiceThrow._1D4();

    [DiceThrow(ThrowType._1D6)]
    public override int GetDamage() => DiceThrow._1D6();

    public override List<Speed> Speeds =>
    [
        new Speed(TravelMode.OnLand, 90)
    ];
}