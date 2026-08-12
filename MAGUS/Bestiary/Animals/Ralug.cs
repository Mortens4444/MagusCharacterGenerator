using MAGUS.Enums;
using MAGUS.GameSystem;
using MAGUS.GameSystem.Attributes;
using MAGUS.Models;
using MAGUS.Things.Armors;
using MAGUS.Things.Weapons;

namespace MAGUS.Bestiary.Animals;

public sealed class Ralug : Creature
{
    public Ralug()
    {
        Armor = new NaturalArmor(2);
        Occurrence = Occurrence.Rare;
        Size = Size.Big;
        PlacesOfOccurrence = TerrainType.CursedLand;

        AttackValue = 80;
        DefenseValue = 110;
        InitiateValue = 18;
        AimValue = 55;

        HealthPoints = 18;
        PainTolerancePoints = 84;

        AstralMagicResistance = 22;
        MentalMagicResistance = 15;
        PoisonResistance = 6;

        Intelligence = Enums.Intelligence.Animal;
        Alignment = Alignment.Death;
        ExperiencePoints = 180;

        AttackModes =
        [
            new MeleeAttack(new BodyPart("Bite", ThrowType._2D10), AttackValue),
            new MeleeAttack(new BodyPart("Tail strike", ThrowType._2D6), AttackValue)
        ];
    }

    public override double AttacksPerRound => 2;

    [DiceThrow(ThrowType._2D10)]
    public override int GetDamage() => DiceThrow._2D10();

    [DiceThrow(ThrowType._1D3)]
    public override int GetNumberAppearing() => DiceThrow._1D3();

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 60)];
}