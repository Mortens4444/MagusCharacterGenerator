using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;
using M.A.G.U.S.Things.Weapons.RangedWeapons;
using M.A.G.U.S.Things.Weapons.StabbingWeapons;

namespace M.A.G.U.S.Bestiary.Races;

public sealed class Slave : Creature
{
    public Slave()
    {
        Occurrence = Occurrence.Frequent; // Only Ediomad
        Size = Size.Human;

        AttackValue = 60;
        DefenseValue = 100;
        InitiateValue = 28;
        AimValue = 30;

        AttacksPerRound = 2;

        AttackModes =
        [
            new MeleeAttack(new ShortSword(), AttackValue),
            new MeleeAttack(new BattleAxe(), AttackValue),
            new RangedAttack(new Shortbow(), AimValue)
        ];

        HealthPoints = 15;
        PainTolerancePoints = 30;

        PoisonResistance = 8;
        AstralMagicResistance = 12;
        MentalMagicResistance = 12;

        Intelligence = Enums.Intelligence.Average;

        ExperiencePoints = 220;

        Alignment = Alignment.ChaosDeath;
    }

    public override string Name => "Slave (Idan Va'Dreeteh)";

    public override string[] Images => ["slave.png"];

    [DiceThrow(ThrowType._1D10)]
    public override int GetNumberAppearing() => DiceThrow._1D10();

    [DiceThrow(ThrowType._1D6)]
    public override int GetDamage() => DiceThrow._1D6();

    public override List<Speed> Speeds =>
    [
        new Speed(TravelMode.OnLand, 80)
    ];
}