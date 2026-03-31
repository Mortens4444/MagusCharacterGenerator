using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Places;
using M.A.G.U.S.Models;
using M.A.G.U.S.Things.Armors;
using M.A.G.U.S.Things.Weapons;

namespace M.A.G.U.S.Bestiary.Animals;

public sealed class Pteropta : Creature
{
    public Pteropta()
    {
        Armor = new NaturalArmor(2);
        Occurrence = Occurrence.Rare;
        Size = Size.Huge;
        PlacesOfOccurrence = TerrainType.Mountains;
        Country = Country.GroUgon | Country.Sheral | Country.Kran;

        AttackValue = 80;
        DefenseValue = 90;
        InitiateValue = 10;

        HealthPoints = 60;
        PainTolerancePoints = 88;

        PoisonResistance = 6;

        Intelligence = Enums.Intelligence.Animal;
        ExperiencePoints = 60;

        AttackModes =
        [
            new MeleeAttack(new BodyPart("Claw", ThrowType._1D10), AttackValue),
            new MeleeAttack(new BodyPart("Horn", ThrowType._2D10), AttackValue),
            new MeleeAttack(new BodyPart("Tail", ThrowType._3D6), AttackValue)
        ];
    }

    public override double AttacksPerRound => 2; // 1

    [DiceThrow(ThrowType._2D10)]
    public override int GetDamage() => DiceThrow._2D10();

    [DiceThrow(ThrowType._1D6)]
    public override int GetNumberAppearing() => DiceThrow._1D6();

    public override List<Speed> Speeds =>
    [
        new Speed(TravelMode.OnLand, 40),
        new Speed(TravelMode.InTheAir, 240)
    ];
}