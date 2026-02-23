using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;
using M.A.G.U.S.Qualifications.Scientific.Psi;
using M.A.G.U.S.Things.Armors;
using M.A.G.U.S.Things.Weapons.CrushingWeapons;
using M.A.G.U.S.Things.Weapons.RangedWeapons;
using M.A.G.U.S.Things.Weapons.StabbingWeapons;

namespace M.A.G.U.S.Bestiary.Races;

public sealed class TruebloodInCombatGear : Creature
{
    public TruebloodInCombatGear()
    {
        Occurrence = Occurrence.VeryRare;
        Size = Size.Human;

        AttackValue = 100;
        DefenseValue = 130;
        InitiateValue = 30;
        AimValue = 0;

        AttacksPerRound = 2;

        AttackModes =
        [
            new MeleeAttack(new TwoHandedHatchet(), AttackValue),
            new MeleeAttack(new TwoHandedHatchet(), AttackValue),
            new MeleeAttack(new Warhammer(), AttackValue),
            new MeleeAttack(new ShortSword(), AttackValue),
            new MeleeAttack(new Longsword(), AttackValue),
            new RangedAttack(new Shortbow(), AimValue),
            new RangedAttack(new Longbow(), AimValue)
        ];

        HealthPoints = 9;
        PainTolerancePoints = 20;

        PoisonResistance = Int32.MaxValue;
        AstralMagicResistance = Int32.MaxValue;
        MentalMagicResistance = Int32.MaxValue;

        Psi = new PsiAntientWay();
        PsiPoints = 100;
        ManaPoints = 100;

        Intelligence = Enums.Intelligence.Outstanding;

        ExperiencePoints = 18000;

        Armor = new AquirianBattleArmor();
        Alignment = Alignment.ChaosDeath;
    }

    public override string Name => "Trueblood (Rachat Ma'Niigan) (in armor)";

    public override string[] Images => ["trueblood.png"];

    [DiceThrow(ThrowType._1D6)]
    public override int GetNumberAppearing() => DiceThrow._1D6();

    [DiceThrow(ThrowType._1D6)]
    public override int GetDamage() => DiceThrow._1D6();

    public override List<Speed> Speeds =>
    [
        new Speed(TravelMode.OnLand, 60)
    ];
}
