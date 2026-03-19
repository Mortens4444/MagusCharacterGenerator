using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;
using M.A.G.U.S.Things.Weapons;

namespace M.A.G.U.S.Bestiary.Mythical;

public sealed class FollowerOfFelice : Creature
{
    public FollowerOfFelice()
    {
        Occurrence = Occurrence.Rare;
        Size = Size.Human;
        //Size = Size.Big;
        PlacesOfOccurrence = TerrainType.Anywhere;

        AttackValue = 60;
        DefenseValue = 90;
        InitiateValue = 40;

        AttacksPerRound = 3;

        AttackModes =
        [
            new MeleeAttack(new BodyPart("Left paw strike", ThrowType._1D5), AttackValue),
            new MeleeAttack(new BodyPart("Right paw strike", ThrowType._1D5), AttackValue),
            new MeleeAttack(new BodyPart("Bite", ThrowType._1D10), AttackValue)
        ];

        HealthPoints = 20;
        PainTolerancePoints = 40;

        PoisonResistance = 5;

        MinIntelligence = Enums.Intelligence.Animal;
        MaxIntelligence = Enums.Intelligence.Average;

        Alignment = Alignment.Animal;

        ExperiencePoints = 75;
    }

    public override string Name => "Follower of Felice";

    [DiceThrow(ThrowType._1D6)]
    public override int GetNumberAppearing() => DiceThrow._1D6();

    [DiceThrow(ThrowType._1D10)]
    public override int GetDamage() => DiceThrow._1D10();

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 180)];
}