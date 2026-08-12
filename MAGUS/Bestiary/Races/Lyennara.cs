using MAGUS.Enums;
using MAGUS.GameSystem;
using MAGUS.GameSystem.Attributes;
using MAGUS.Models;
using MAGUS.Things.Weapons.CrushingWeapons;
using MAGUS.Things.Weapons.RangedWeapons;
using MAGUS.Things.Weapons.StabbingWeapons;

namespace MAGUS.Bestiary.Races;

public sealed class Lyennara : Creature
{
    public Lyennara()
    {
        Size = Size.Human;
        Alignment = Alignment.OrderLife;
        PlacesOfOccurrence = TerrainType.Anywhere;

        AttackValue = 45;
        DefenseValue = 135;
        InitiateValue = 25;
        AimValue = 35;

        HealthPoints = 15;
        PainTolerancePoints = 98;
        AttackModes =
        [
            new MeleeAttack(new Warhammer(), AttackValue),
            new MeleeAttack(new TwoHandedMace(), AttackValue),
            new MeleeAttack(new ShortSword(), AttackValue),
            new MeleeAttack(new Longsword(), AttackValue),
            new RangedAttack(new Shortbow(), AimValue),
            new RangedAttack(new Longbow(), AimValue)
        ];

        AstralMagicResistance = Int32.MaxValue;
        MentalMagicResistance = 180;
        PoisonResistance = 19;

        ManaPoints = 160;

        Intelligence = Enums.Intelligence.Outstanding;
        ExperiencePoints = 35000;

        // Occurrence = see description;
        // Number appearing = see description;
        // Speed = variable;
        // Psi = see description;
        // Damage = weapon dependent;
    }

    [DiceThrow(ThrowType._1D6)]
    public override int GetDamage() => DiceThrow._1D6(); // Weapon dependent

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1; // See description

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 110)];
}