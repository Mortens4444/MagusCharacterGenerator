using MAGUS.Enums;
using MAGUS.GameSystem;
using MAGUS.GameSystem.Attributes;
using MAGUS.Models;
using MAGUS.Qualifications.Scientific.Psi;
using MAGUS.Things.Weapons.RangedWeapons;
using MAGUS.Things.Weapons.StabbingWeapons;

namespace MAGUS.Bestiary.Races;

public sealed class Myssera : Creature
{
    public Myssera()
    {
        Occurrence = Occurrence.Rare;
        Size = Size.Human;
        PlacesOfOccurrence = TerrainType.CursedLand;

        AttackValue = 55;
        DefenseValue = 105;
        InitiateValue = 25;
        AimValue = 15;

        AttackModes =
        [
            new RangedAttack(new HandCrossbow(), AimValue),
            new MeleeAttack(new Longsword(), AttackValue),
            new MeleeAttack(new Dagger(), AttackValue)
        ];

        HealthPoints = 9;
        PainTolerancePoints = 35;

        PoisonResistance = 6;
        AstralMagicResistance = 15;
        MentalMagicResistance = 15;

        Intelligence = Enums.Intelligence.Outstanding;

        ExperiencePoints = 360;

        Alignment = Alignment.Chaos;

        Psi = new PsiKyrMethod();
        PsiPoints = 50;
        ManaPoints = 60;
    }

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    [DiceThrow(ThrowType._1D6)]
    public override int GetDamage() => DiceThrow._1D6();

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 100)];
}