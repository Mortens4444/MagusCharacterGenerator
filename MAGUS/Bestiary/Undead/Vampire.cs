using MAGUS.Enums;
using MAGUS.GameSystem;
using MAGUS.GameSystem.Attributes;
using MAGUS.Models;
using MAGUS.Things.Weapons;
using MAGUS.Things.Weapons.StabbingWeapons;

namespace MAGUS.Bestiary.Undead;

public sealed class Vampire : LivingDead
{
    public Vampire()
    {
        //Strength = 20;
        Occurrence = Occurrence.Rare;
        Size = Size.Human;
        PlacesOfOccurrence = TerrainType.Anywhere;

        AttackValue = 80;
        DefenseValue = 120;
        InitiateValue = 32;

        AttackModes =
        [
            new MeleeAttack(new BodyPart("Tooth", ThrowType._1D6), AttackValue),
            new MeleeAttack(new Longsword(), AttackValue)
        ];

        HealthPoints = 40; // Regenerate 1 HP per turn

        AstralMagicResistance = Int32.MaxValue;
        MentalMagicResistance = Int32.MaxValue;
        PoisonResistance = Int32.MaxValue;

        Intelligence = Enums.Intelligence.High;
        Alignment = Alignment.ChaosDeath;
        ExperiencePoints = 4000;
        NecrographyDepartment = NecrographyDepartment.BloodDrinkingUndead;
    }

    [DiceThrow(ThrowType._1D6)]
    public override int GetDamage() => DiceThrow._1D6();

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    public override double AttacksPerRound => 2;

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 100)];
}
