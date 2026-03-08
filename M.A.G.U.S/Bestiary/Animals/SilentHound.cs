using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;
using M.A.G.U.S.Things.Weapons;

namespace M.A.G.U.S.Bestiary.Animals;

public sealed class SilentHound : Creature
{
    public SilentHound()
    {
        Occurrence = Occurrence.VeryRare;
        Size = Size.Big;
        PlacesOfOccurrence = TerrainType.AbbitMines;
        Country = GameSystem.Places.Country.Abasis;

        AttackValue = 105;
        DefenseValue = 145;
        InitiateValue = 40;
        AimValue = 0;

        AttacksPerRound = 3;
        AttackModes =
        [
            new MeleeAttack(new BodyPart("Rend", ThrowType._2D6, 2), AttackValue),
            new MeleeAttack(new BodyPart("Claw", ThrowType._1D10, 2), AttackValue),
            new MeleeAttack(new BodyPart("Bite", ThrowType._1D10), AttackValue)
        ];

        HealthPoints = 16;
        PainTolerancePoints = 65;

        AstralMagicResistance = 6;
        MentalMagicResistance = 3;
        PoisonResistance = 8;

        Intelligence = Enums.Intelligence.Low;

        ExperiencePoints = 420;
    }

    public override string Name => "Silent hound";

    [DiceThrow(ThrowType._1D3)]
    public override int GetNumberAppearing() => DiceThrow._1D3();

    [DiceThrow(ThrowType._2D6)]
    public override int GetDamage() => DiceThrow._2D6();

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 140)];
}