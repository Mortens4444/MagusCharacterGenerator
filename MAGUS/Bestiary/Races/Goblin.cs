using MAGUS.Enums;
using MAGUS.GameSystem;
using MAGUS.GameSystem.Attributes;
using MAGUS.Models;
using MAGUS.Things.Weapons.CrushingWeapons;
using MAGUS.Things.Weapons.RangedWeapons;
using MAGUS.Things.Weapons.StabbingWeapons;

namespace MAGUS.Bestiary.Races;

public sealed class Goblin : Creature
{
    public Goblin()
    {
        Occurrence = Occurrence.Rare;
        Size = Size.Small;
        PlacesOfOccurrence = TerrainType.Cave | TerrainType.Mines | TerrainType.OldDilapidatedBuilding;

        AttackValue = 25;
        DefenseValue = 60;
        InitiateValue = 10;
        AimValue = 0;

        AttackModes =
        [
            new MeleeAttack(new CarvedClub(), AttackValue),
            new MeleeAttack(new ShortSword(), AttackValue),
            new RangedAttack(new GoblinBow(), AimValue)
        ];

        HealthPoints = 7;
        PainTolerancePoints = 12;

        PoisonResistance = 3;

        Intelligence = Enums.Intelligence.Low;
        Alignment = Alignment.Chaos;
        ExperiencePoints = 10;
    }

    [DiceThrow(ThrowType._1D6)]
    public override int GetDamage() => DiceThrow._1D6();

    [DiceThrow(ThrowType._10D10)]
    public override int GetNumberAppearing() => DiceThrow._10D10();

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 65)];
}
