using MAGUS.Enums;
using MAGUS.GameSystem;
using MAGUS.GameSystem.Attributes;
using MAGUS.GameSystem.Magic.Spells.Mosaic;
using MAGUS.GameSystem.Psi.Disciplines.Kyr;
using MAGUS.Models;
using MAGUS.Qualifications.Scientific.Psi;
using MAGUS.Things.Weapons.CrushingWeapons;
using MAGUS.Things.Weapons.RangedWeapons;
using MAGUS.Things.Weapons.StabbingWeapons;

namespace MAGUS.Bestiary.Mythical;

public sealed class DreamCrystal : Creature
{
    public DreamCrystal()
    {
        // Willpower 14 + k6
        Occurrence = Occurrence.VeryRare;
        Size = Size.Maximum_1_meter;
        PlacesOfOccurrence = TerrainType.Cave;

        AttackModes =
        [
            new PsiAttack(new MindBlast()),
            new SpellAttack(new MagicMissile()),
            new MeleeAttack(new Warhammer(), AttackValue),
            new MeleeAttack(new TwoHandedMace(), AttackValue),
            new MeleeAttack(new ShortSword(), AttackValue),
            new MeleeAttack(new Longsword(), AttackValue),
            new RangedAttack(new Shortbow(), AimValue),
            new RangedAttack(new Longbow(), AimValue)
        ];

        AttackValue = 35;
        DefenseValue = 96;
        InitiateValue = 25;
        AimValue = 4;

        HealthPoints = 20;

        AstralMagicResistance = 140;
        MentalMagicResistance = 170;
        PoisonResistance = Int32.MaxValue;

        Psi = new PsiKyrMethod();
        PsiPoints = 70;
        ManaPoints = 100;

        Intelligence = Enums.Intelligence.Outstanding;
        Alignment = Alignment.Various;
        ExperiencePoints = 7500;
    }

    public override string Name => "Dream crystal";

    [DiceThrowModifier(0)]
    public override int GetDamage() => 0;

    [DiceThrow(ThrowType._1D3)]
    public override int GetNumberAppearing() => DiceThrow._1D3();

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 100)];
}
