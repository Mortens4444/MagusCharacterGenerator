using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;
using M.A.G.U.S.Things.Weapons.RangedWeapons;
using M.A.G.U.S.Things.Weapons.StabbingWeapons;

namespace M.A.G.U.S.Bestiary.Races;

public sealed class DarkElf : Creature
{
    public DarkElf()
    {
        Occurrence = Occurrence.VeryRare;
        Size = Size.Human;
        AttackValue = 200; // 250
        DefenseValue = 220; // 280
        InitiateValue = 85;
        AimValue = 60;
        AttackModes =
        [
            new MeleeAttack(new Sequor(), AttackValue),
            new MeleeAttack(new MaraSequor(), AttackValue),
            new RangedAttack(new AquirianCrossbow(), AimValue),
        ];

        AttacksPerRound = 4;

        HealthPoints = 17;
        MinPainTolerancePoints = 150;
        MaxPainTolerancePoints = 220;

        PoisonResistance = Int32.MaxValue;
        AstralMagicResistance = 120; // 140
        MentalMagicResistance = 120; // 140
        Intelligence = Enums.Intelligence.Outstanding;
        Alignment = Alignment.ChaosDeath;
        ExperiencePoints = 90000;
    }

    [DiceThrow(ThrowType._1D6)]
    public override int GetDamage() => DiceThrow._1D6();

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    public override string Name => "Dark elf";

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 150)];
}
