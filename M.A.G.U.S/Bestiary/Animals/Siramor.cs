using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;
using M.A.G.U.S.Things.Armors;
using M.A.G.U.S.Things.Weapons;

namespace M.A.G.U.S.Bestiary.Animals;

public sealed class Siramor : Creature
{
    public Siramor()
    {
        Occurrence = Occurrence.Rare;
        Size = Size.Human;
        PlacesOfOccurrence = TerrainType.DeepUnderground;

        Armor = new NaturalArmor(2);

        AttackValue = 55;
        DefenseValue = 75;
        InitiateValue = 10;

        AttackModes =
        [
            new MeleeAttack(new BodyPart("Bite", ThrowType._2D6), AttackValue)
        ];

        HealthPoints = 18;
        PainTolerancePoints = 42;

        AstralMagicResistance = 0;
        MentalMagicResistance = 0;
        PoisonResistance = 7;

        Intelligence = Enums.Intelligence.Animal;
        ExperiencePoints = 75;
    }

    [DiceThrow(ThrowType._1D6)]
    public override int GetNumberAppearing() => DiceThrow._1D6();

    [DiceThrow(ThrowType._2D6)]
    public override int GetDamage() => DiceThrow._2D6();

    public override double AttacksPerRound => 1;

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 80), new Speed(TravelMode.InWater, 60), new Speed(TravelMode.OnWalls, 30)];
}