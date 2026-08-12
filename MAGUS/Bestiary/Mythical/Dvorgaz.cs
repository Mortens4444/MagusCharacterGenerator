using MAGUS.Enums;
using MAGUS.GameSystem;
using MAGUS.GameSystem.Attributes;
using MAGUS.Models;
using MAGUS.Things.Weapons.RangedWeapons;
using MAGUS.Things.Weapons.StabbingWeapons;

namespace MAGUS.Bestiary.Mythical;

public sealed class Dvorgaz : Creature
{
    public Dvorgaz()
    {
        Occurrence = Occurrence.VeryRare;
        Size = Size.Small;
        PlacesOfOccurrence = TerrainType.Urban | TerrainType.Catacombs | TerrainType.Sewer | TerrainType.DeepUnderground;

        AttackValue = 45;
        DefenseValue = 115;
        InitiateValue = 35;
        AimValue = 35;

        AttackModes =
        [
            new MeleeAttack(new Dagger(), AttackValue),
            new RangedAttack(new Sling(), AimValue)
        ];

        HealthPoints = 5;
        PainTolerancePoints = 29;

        AstralMagicResistance = 25;
        MentalMagicResistance = 35;
        PoisonResistance = 6;

        Intelligence = Enums.Intelligence.Average;
        Alignment = Alignment.ChaosDeath;
        ExperiencePoints = 175;
    }

    [DiceThrow(ThrowType._1D4)]
    public override int GetDamage() => DiceThrow._1D4();

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 160)];

    //public override string[] Sounds => ["dvorgaz_hiss", "dvorgaz_screech"];
}