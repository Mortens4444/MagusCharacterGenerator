using MAGUS.Enums;
using MAGUS.GameSystem;
using MAGUS.GameSystem.Attributes;
using MAGUS.Models;
using MAGUS.Things.Weapons;
using MAGUS.Things.Weapons.StabbingWeapons;

namespace MAGUS.Bestiary.Races;

public sealed class Feenhar : Creature
{
    public Feenhar()
    {
        Occurrence = Occurrence.Rare;
        Size = Size.Human;
        PlacesOfOccurrence = TerrainType.Mountains;

        AttackValue = 45;
        DefenseValue = 80;
        InitiateValue = 25;
        AimValue = 0;

        AttackModes =
        [
            new MeleeAttack(new CommonWeapon("Weapon", 5, 10, 15, ThrowType._1D10, 2, true), AttackValue),
            new MeleeAttack(new Breeze(), AttackValue),
        ];

        HealthPoints = 20;
        PainTolerancePoints = 60;

        AstralMagicResistance = 70;
        MentalMagicResistance = 70;
        PoisonResistance = 20;

        Intelligence = Enums.Intelligence.High;
        Alignment = Alignment.DeathOrder;
        ExperiencePoints = 105;
    }

    [DiceThrow(ThrowType._1D10)]
    [DiceThrowModifier(2)]
    public override int GetDamage() => DiceThrow._1D10() + 2;

    [DiceThrow(ThrowType._1D6)]
    public override int GetNumberAppearing() => DiceThrow._1D6();

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 80), new Speed(TravelMode.InTheAir, 60)];
}
