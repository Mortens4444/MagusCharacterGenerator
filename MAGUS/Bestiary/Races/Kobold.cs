using MAGUS.Enums;
using MAGUS.GameSystem;
using MAGUS.GameSystem.Attributes;
using MAGUS.Models;
using MAGUS.Things.Armors;
using MAGUS.Things.Weapons;
using MAGUS.Things.Weapons.RangedWeapons;
using MAGUS.Things.Weapons.Spears;
using MAGUS.Things.Weapons.StabbingWeapons;

namespace MAGUS.Bestiary.Races;

public sealed class Kobold : Creature
{
    public Kobold()
    {
        Armor = new NaturalArmor(3);
        Occurrence = Occurrence.Frequent;
        Size = Size.Small;
        PlacesOfOccurrence =
            TerrainType.Cave |
            TerrainType.Underground |
            TerrainType.DeepUnderground |
            TerrainType.Mountains |
            TerrainType.Tunnels;

        AttackValue = 65;
        DefenseValue = 110;
        InitiateValue = 35;
        AimValue = 28;

        AttackModes =
        [
            new MeleeAttack(new BattleAxe(), AttackValue),
            new MeleeAttack(new ShortSword(), AttackValue),
            new MeleeAttack(new LightLance(), AttackValue),
            new RangedAttack(new Shortbow(), AimValue),
            new MeleeAttack(new BodyPart("Claw strike", ThrowType._1D6), AttackValue),
            new MeleeAttack(new BodyPart("Bite", ThrowType._1D10), AttackValue)
        ];

        HealthPoints = 9;
        PainTolerancePoints = 48;

        AstralMagicResistance = 25;
        MentalMagicResistance = 30;
        PoisonResistance = Int32.MaxValue;

        Intelligence = Enums.Intelligence.Average;
        Alignment = Alignment.ChaosDeath;
        ExperiencePoints = 45;
    }

    public override double AttacksPerRound => 2;

    [DiceThrow(ThrowType._1D10)]
    public override int GetDamage() => DiceThrow._1D10();

    [DiceThrow(ThrowType._5D10)]
    public override int GetNumberAppearing() => DiceThrow._5D10();

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 90)];
}