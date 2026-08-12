using MAGUS.Enums;
using MAGUS.GameSystem;
using MAGUS.GameSystem.Attributes;
using MAGUS.Models;
using MAGUS.Qualifications.Scientific.Psi;
using MAGUS.Things.Armors;
using MAGUS.Things.Weapons.CrushingWeapons;
using MAGUS.Things.Weapons.RangedWeapons;
using MAGUS.Things.Weapons.StabbingWeapons;

namespace MAGUS.Bestiary.Races;

public sealed class TruebloodInCombatGear : Creature
{
    public TruebloodInCombatGear()
    {
        Occurrence = Occurrence.VeryRare;
        Size = Size.Human;
        PlacesOfOccurrence = TerrainType.Tunnels;
        Country = GameSystem.Places.Country.Ediomad;

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

    public override string[] Images => ["trueblood_in_armor.png"];

    [DiceThrow(ThrowType._1D6)]
    public override int GetNumberAppearing() => DiceThrow._1D6();

    [DiceThrow(ThrowType._1D6)]
    public override int GetDamage() => DiceThrow._1D6();

    public override List<Speed> Speeds =>
    [
        new Speed(TravelMode.OnLand, 60)
    ];
}
