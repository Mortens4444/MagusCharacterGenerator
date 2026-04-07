using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;
using M.A.G.U.S.Things.Weapons;

namespace M.A.G.U.S.Bestiary.Mythical;

public sealed class Ilflind : Creature
{
    public Ilflind()
    {
        Occurrence = Occurrence.VeryRare;
        Size = Size.Human;
        PlacesOfOccurrence = TerrainType.VolcanicShaft | TerrainType.Volcano | TerrainType.Cave | TerrainType.LavaLake;

        AttackValue = 49;
        DefenseValue = 96;
        InitiateValue = 25;

        AttackModes =
        [
            new MeleeAttack(new BodyPart("Left burning touch", ThrowType._1D6), AttackValue),
            new MeleeAttack(new BodyPart("Right burning touch", ThrowType._1D6), AttackValue)
        ];

        HealthPoints = 35;
        PainTolerancePoints = 100;

        AstralMagicResistance = 15;
        MentalMagicResistance = 17;
        PoisonResistance = Int32.MaxValue;

        Intelligence = Enums.Intelligence.Average;
        Alignment = Alignment.Order;
        ExperiencePoints = 275;
    }

    public override double AttacksPerRound => 2;

    [DiceThrow(ThrowType._1D6)]
    public override int GetDamage() => DiceThrow._1D6();

    [DiceThrow(ThrowType._1D6)]
    public override int GetNumberAppearing() => DiceThrow._1D6();

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 90)];
}