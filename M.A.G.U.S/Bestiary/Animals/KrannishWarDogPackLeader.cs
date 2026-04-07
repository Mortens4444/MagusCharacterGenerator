using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;
using M.A.G.U.S.Things.Weapons;

namespace M.A.G.U.S.Bestiary.Animals;

public sealed class KrannishWarDogPackLeader : Creature
{
    public KrannishWarDogPackLeader()
    {
        Occurrence = Occurrence.Rare;
        Size = Size.Huge;
        Country = GameSystem.Places.Country.Kran;
        PlacesOfOccurrence = TerrainType.Anywhere;

        AttackValue = 100;
        DefenseValue = 125;
        InitiateValue = 40;

        AttackModes =
        [
            new MeleeAttack(new BodyPart("Left claw", ThrowType._1D6, 1), AttackValue),
            new MeleeAttack(new BodyPart("Right claw", ThrowType._1D6, 1), AttackValue),
            new MeleeAttack(new BodyPart("Bite", ThrowType._1D10, 1), AttackValue)
        ];

        HealthPoints = 25;
        PainTolerancePoints = 85;

        AstralMagicResistance = Int32.MaxValue;
        MentalMagicResistance = Int32.MaxValue;
        PoisonResistance = 15;

        Intelligence = Enums.Intelligence.Animal;
        Alignment = Alignment.ChaosDeath;
        ExperiencePoints = 255;

        // Psi = special
    }

    public override string Name => "Krannish War Dog Pack Leader";

    public override string[] Images => ["krannish_war_dog.png"];

    public override double AttacksPerRound => 3;

    [DiceThrow(ThrowType._1D10)]
    [DiceThrowModifier(1)]
    public override int GetDamage() => DiceThrow._1D10() + 1;

    [DiceThrow(ThrowType._1D6)]
    public override int GetNumberAppearing() => DiceThrow._1D6();

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 125)];
}

