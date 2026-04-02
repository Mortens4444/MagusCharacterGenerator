using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;
using M.A.G.U.S.Things.Armors;

namespace M.A.G.U.S.Bestiary.Animals;

public sealed class SeaSnake : Creature
{
    public SeaSnake()
    {
        Armor = new NaturalArmor(20); // 15-25, Fején 10-15
        Occurrence = Occurrence.VeryRare;
        Size = Size.Huge; // 800-1300 láb hosszú, átmérője 25 láb
        PlacesOfOccurrence = TerrainType.SaltWater;

        AttackValue = 120;
        InitiateValue = 0;

        HealthPoints = 250; // Fején 100
        PainTolerancePoints = 500; // Fején 200

        AstralMagicResistance = Int32.MaxValue;
        MentalMagicResistance = Int32.MaxValue;
        PoisonResistance = Int32.MaxValue;

        Intelligence = Enums.Intelligence.Low;
        ExperiencePoints = 50000;
    }

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    // A pontos sebzés a példány méretétől függ.
    [DiceThrow(ThrowType._10D10)]
    public override int GetDamage() => DiceThrow._10D10();

    public override double AttacksPerRound => 0.5;

    public override List<Speed> Speeds => [new Speed(TravelMode.InWater, 50)];

    public override string Name => "Sea Snake (Aipus Laevys)";

    public override string[] Images => ["sea_snake.png"];
}