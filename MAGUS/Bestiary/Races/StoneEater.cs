using MAGUS.Enums;
using MAGUS.GameSystem;
using MAGUS.GameSystem.Attributes;
using MAGUS.Models;
using MAGUS.Things.Armors;
using MAGUS.Things.Weapons;

namespace MAGUS.Bestiary.Races;

public sealed class StoneEater : Creature
{
    public StoneEater()
    {
        Armor = new NaturalArmor(5);
        Occurrence = Occurrence.Rare;
        Size = Size.Big;
        PlacesOfOccurrence = TerrainType.Mountains | TerrainType.Hills | TerrainType.Crevice;

        AttackValue = 65;
        DefenseValue = 95;
        InitiateValue = 0;

        AttackModes =
        [
            new MeleeAttack(new BodyPart("Stone-crushing fist", ThrowType._3D6, 6), AttackValue)
        ];

        HealthPoints = 50;
        PainTolerancePoints = 90;

        AstralMagicResistance = 30;
        MentalMagicResistance = 15;
        PoisonResistance = Int32.MaxValue;

        Intelligence = Enums.Intelligence.Low;
        ExperiencePoints = 880;
    }

    public override string Name => "Stone Eater";

    [DiceThrow(ThrowType._3D6)]
    [DiceThrowModifier(6)]
    public override int GetDamage() => DiceThrow._3D6() + 6;

    [DiceThrow(ThrowType._1D2)]
    [DiceThrowModifier(2)]
    public override int GetNumberAppearing() => DiceThrow._1D2() + 2;

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 40)];
}